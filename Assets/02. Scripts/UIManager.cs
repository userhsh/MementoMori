using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    //�޴�â�� �ִ� ���
    public GameObject UIMenu;
    public GameObject optionButton;
    public GameObject exitButton;

    //����ǰ�� �ִ� ���
   public bool[] collections = new bool[4];

    public GameObject[] collectionButtonLocks;
    public GameObject[] collectionButtons;
    public GameObject collectionLockImg;
    public GameObject[] collectionImgs;


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
    private void Update()
    {
        //����ǰ ȹ�� �� ����ǰUI�� ��ư �ر�
        if (collections[0] == true)
        {
            collectionButtonLocks[0].gameObject.SetActive(false);
            collectionButtons[0].gameObject.SetActive(true);
        }
       if (collections[1] == true)
        {
            collectionButtonLocks[1].gameObject.SetActive(false);
            collectionButtons[1].gameObject.SetActive(true);
        }
       if (collections[2] == true)
        {
            collectionButtonLocks[2].gameObject.SetActive(false);
            collectionButtons[2].gameObject.SetActive(true);
        }
       if (collections[3] == true)
        {
            collectionButtonLocks[3].gameObject.SetActive(false);
            collectionButtons[3].gameObject.SetActive(true);
        }


        CheckCollection();

    }

    public void ReturnButton() //���ư��� ��ư ���� �� �޴� ����
    {
        UIMenu.SetActive(false);
    }
    public void OptionButton()
    {

    }
    public void ExitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameStartScene");
    }

    public void CollectionOpen(int _collectionNuber)
    {
        for (int i = 0; i < collectionImgs.Length; i++)
        {
            collectionImgs[i].gameObject.SetActive(false);
        }
        switch (_collectionNuber)
        {
            case 0:
                collectionLockImg.gameObject.SetActive(false);
                collectionImgs[0].gameObject.SetActive(true);
                break;
            case 1:
                collectionLockImg.gameObject.SetActive(false);
                collectionImgs[1].gameObject.SetActive(true);
                break;
            case 2:
                collectionLockImg.gameObject.SetActive(false);
                collectionImgs[2].gameObject.SetActive(true);
                break;
            case 3:
                collectionLockImg.gameObject.SetActive(false);
                collectionImgs[3].gameObject.SetActive(true);
                break;
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


}
