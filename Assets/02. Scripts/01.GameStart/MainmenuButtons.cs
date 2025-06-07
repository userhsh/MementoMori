using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuButtons : MonoBehaviour
{
    Button[] buttons = null; // ��ư �迭

    public GameObject Mainmenu; // ���� �޴� ���� ������Ʈ
    public GameObject Optionmenu; // �ɼ� �޴� ���� ������Ʈ
    public GameObject TutorialMenu;
    public GameObject CreditMenu; //ũ����â
    public Button creditButton; // �̾��ϱ� ��ư ���� �߰�

    private const int NewGameButtonIndex = 0; // �� ���� ��ư �ε���
    private const int CreditButtonIndex = 1; // �̾��ϱ� ��ư �ε���
    private const int OptionButtonIndex = 2; // �ɼ� ��ư �ε���
    private const int ExitButtonIndex = 3; // ���� ��ư �ε���

    private void Awake()
    {
        // ���� ������Ʈ�� �ڽĿ��� ��ư ������Ʈ�� ������ �迭�� ����
        buttons = GetComponentsInChildren<Button>();

        // ��ư ������ ������ ��� ���� �α� ���
        if (buttons.Length < 4)
        {
            return;
        }

        // �̾��ϱ� ��ư ����
        creditButton = buttons[CreditButtonIndex];

        languageEnglishCheck();
    }

    private void Start()
    {
        // �� ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        buttons[NewGameButtonIndex].onClick.AddListener(NewGame);  // �� ���� ��ư
        buttons[CreditButtonIndex].onClick.AddListener(Credit);  // ũ���� ��ư
        buttons[OptionButtonIndex].onClick.AddListener(EnterOption);  // �ɼ� �޴� ��ư
        buttons[ExitButtonIndex].onClick.AddListener(GameExit);   // ���� ���� ��ư

        // GameManager���� �̾��ϱ� ��ư ���¸� ������ ����
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            //continueButton.interactable = gameManager.isContinueAvailable; // �̾��ϱ� ��ư�� Ȱ��ȭ ���� ����
        }
        else
        {
            creditButton.interactable = false; // GameManager�� ������ ��Ȱ��ȭ
        }


    }

    void NewGame() // �� ���� ����
    {
        TutorialMenu.SetActive(true);
        Mainmenu.SetActive(false);
    }

    void Credit() //ũ��������  // �̾��ϱ�
    {
        // GameManager.Instance.isTutorial = false;
        // SceneManager.LoadScene("LoadingScene");  // �ε� �� �ε�

        Mainmenu.SetActive(false);  // ���� �޴� ��Ȱ��ȭ
        CreditMenu.SetActive(true); //ũ���� �޴� Ȱ��
    }

    void EnterOption() // �ɼ� �޴��� ��ȯ
    {
        Mainmenu.SetActive(false);  // ���� �޴� ��Ȱ��ȭ
        Optionmenu.SetActive(true); // �ɼ� �޴� Ȱ��ȭ
    }

    void GameExit() // ���� ���� ó��
    {
        // ���� ������ �÷��̾�� GameManager�� ã��
        PlayerController playerController = FindObjectOfType<PlayerController>();
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (playerController != null && gameManager != null)
        {
            // �÷��̾��� ��ġ�� ȸ������ ����
            Vector3 playerPosition = playerController.transform.position; // �÷��̾� ��ġ
            Vector3 playerRotation = playerController.transform.rotation.eulerAngles; // �÷��̾� ȸ����

            gameManager.SaveGameData(playerPosition, playerRotation); // �÷��̾� ��ġ�� ȸ���� ����
        }

#if UNITY_EDITOR    // ����Ƽ �����Ϳ��� ���� ���� ��
        UnityEditor.EditorApplication.isPlaying = false; // �÷��� ��� ����
#else   // �� �� ���ø����̼��� ��
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    public GameObject engCheckBox;
    public GameObject korCheckBox;
    public GameObject tutolanguageEng;
    public GameObject tutolanguageKor;
    public GameObject creditEng;
    public GameObject creditKor;
    public GameObject[] StartSceneEnglish;
    public GameObject[] StartSceneKorean;

    public void languageEnglishCheck() //������ üũ �� 
    {   //���ӸŴ����� ���� ���� true ���� �ѱ�
        GameObject.Find("GameManager").GetComponent<GameManager>().languageKor = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().languageEng = true;
        //���ο� �ִ� �ؽ�Ʈ �� �̹����� ����� ��ü �� Ȱ��
        for (int i = 0; i < StartSceneKorean.Length; i++)
        {
            StartSceneKorean[i].SetActive(false);
        }
        for (int i = 0; i < StartSceneEnglish.Length; i++)
        {
            StartSceneEnglish[i].SetActive(true);
        }
    }
    public void languageKoreanCheck() //�ѱ���� üũ �� 
    {   //���ӸŴ����� �ѱ��� ���� true ���� �ѱ�
        GameObject.Find("GameManager").GetComponent<GameManager>().languageEng = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().languageKor = true;
        //���ο� �ִ� �ؽ�Ʈ �� �̹����� �ѱ���� ��ü �� Ȱ��
        for (int i = 0; i < StartSceneEnglish.Length; i++)
        {
            StartSceneEnglish[i].SetActive(false);
        }
        for (int i = 0; i < StartSceneKorean.Length; i++)
        {
            StartSceneKorean[i].SetActive(true);
        }
       
    }

    // �̾��ϱ� ��ư ���� ������Ʈ �޼���
    public void UpdateContinueButton(bool isContinueAvailable)
    {
        //continueButton.interactable = isContinueAvailable; // ��ư�� interactable ���� ������Ʈ
    }
}
