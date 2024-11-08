using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private GameManager gameManager; // GameManager ���� ����

    //�޴�â�� �ִ� ���
    public GameObject UIMenu;
    public GameObject UIMenuerPaper;
    public GameObject OptionMenu;
    public GameObject optionButton;
    public GameObject exitButton;

    //����ǰ�� �ִ� ���
    public bool[] collections = new bool[4];
    public GameObject[] collectionButtonLocks;
    public GameObject[] collectionButtons;
    public GameObject collectionLockImg;
    public GameObject[] collectionImgs;

    public LeftController leftController;

    public UITalk uITalk;
    public int collectTalkCount = 0;

    private bool isAllCollection = false;
    public bool IsAllCollection { get { return isAllCollection; } }

    int collectionCount = 0;

    private void Awake()
    {
        for (int i = 0; i < collections.Length; i++)
        {
            collections[i] = false;
        }
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            //Debug.Log("GameManager not found in the scene!");
        }
    }

    private void Update()
    {
        // ����ǰ ȹ�� �� ����ǰUI�� ��ư �ر�
        for (int i = 0; i < collections.Length; i++)
        {
            if (collections[i] == true)
            {
                collectionButtonLocks[i].gameObject.SetActive(false);
                collectionButtons[i].gameObject.SetActive(true);
            }
        }

        CheckCollection();
    }

    public void ReturnButton() //���ư��� ��ư ���� �� �޴� ����
    {
        UIMenu.SetActive(false);
    }
    public void MenuerButton() //�޴��� ��ư ���� �� ���۰��� UI ����
    {
        UIMenuerPaper.SetActive(true);
        UIMenu.SetActive(false);

    }

    public void OptionButton()
    {
        UIMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }
    public void ExitButton()
    {
        leftController.RemoveEvent();

        if (gameManager != null)
        {
            // Exit ��ư�� Ŭ������ �� ������ �۾�
            PlayerController playerController = FindObjectOfType<PlayerController>(); // ���� ������ �÷��̾� ��ü�� ã��
            if (playerController != null)
            {
                // �÷��̾��� ��ġ�� ȸ������ ����
                Vector3 playerPosition = playerController.transform.position; // �÷��̾� ��ġ
                Vector3 playerRotation = playerController.transform.rotation.eulerAngles; // �÷��̾� ȸ����

                gameManager.SaveGameData(playerPosition, playerRotation); // �÷��̾� ��ġ�� ȸ���� ����
            }
            else
            {
                Debug.Log("PlayerController not found in ExitButton!");
            }
        }
        else
        {
            //Debug.Log("GameManager is null in ExitButton!");
        }

        SceneManager.LoadScene("GameStartScene"); // ù ��° ������ ��ȯ
    }

    public void CollectionOpen(int _collectionNumber)
    {
        for (int i = 0; i < collectionImgs.Length; i++)
        {
            collectionImgs[i].gameObject.SetActive(false);
        }
        if (_collectionNumber >= 0 && _collectionNumber < collectionImgs.Length)
        {
            collectionLockImg.gameObject.SetActive(false);
            collectionImgs[_collectionNumber].gameObject.SetActive(true);
        }
    }


    private void CheckCollection()
    {
        collectionCount = 0;

        for (int i = 0; i < collections.Length; i++)
        {
            if (collections[i])
            {
                collectionCount++;
            }
        }

        if (collectionCount >= 4)
        {
            isAllCollection = true;
        }
    }
    public IEnumerator CollectGetTalkCountColltin()
    {

        yield return new WaitForSeconds(3f);

        GameObject.Find("Left Controller").GetComponent<LeftController>().enabled = false;
        GameObject.Find("Right Controller").GetComponent<RightController>().enabled = false;

        switch (collectTalkCount)
        {
            case 1:

                StartCoroutine(uITalk.InteractionTalk("'��'�� �� �̷� ����\n�ִ� �ɱ�."));
                break;
            case 2:

                StartCoroutine(uITalk.InteractionTalk("���� ���� �� ����\n���� ���ö���."));
                break;
            case 3:

                StartCoroutine(uITalk.InteractionTalk("���� �� �������� �ǹ� �ִ�\n���翴�� ������ ��."));
                break;
            case 4:

                StartCoroutine(uITalk.InteractionTalk("���� ������. \n���ݸ� �� �Ű� ������..."));
                break;
        }

        yield break;
    }
    public void CollectGetTalkCount()
    {

        StartCoroutine(CollectGetTalkCountColltin());



    }


}
