using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuButtons : MonoBehaviour
{
    Button[] buttons = null; // ��ư �迭
    private GameObject Mainmenu; // ���� �޴� ���� ������Ʈ
    private GameObject Optionmenu; // �ɼ� �޴� ���� ������Ʈ

    private Button continueButton; // �̾��ϱ� ��ư ���� �߰�

    private const int NewGameButtonIndex = 0; // �� ���� ��ư �ε���
    private const int ContinueButtonIndex = 1; // �̾��ϱ� ��ư �ε���
    private const int OptionButtonIndex = 2; // �ɼ� ��ư �ε���
    private const int ExitButtonIndex = 3; // ���� ��ư �ε���

    private void Awake()
    {
        // ���� �޴��� �ɼ� �޴� ���� ������Ʈ ã��
        Mainmenu = GameObject.Find("Main menu");
        Optionmenu = GameObject.Find("Option menu");

        // ���� ������Ʈ�� �ڽĿ��� ��ư ������Ʈ�� ������ �迭�� ����
        buttons = GetComponentsInChildren<Button>();

        // ��ư ������ ������ ��� ���� �α� ���
        if (buttons.Length < 4)
        {
            Debug.LogError("��ư ������ �����մϴ�. ���� ��ư ����: " + buttons.Length);
            return;
        }

        // �̾��ϱ� ��ư ����
        continueButton = buttons[ContinueButtonIndex];
    }

    private void Start()
    {
        Optionmenu.SetActive(false); // �ɼ� �޴� ��Ȱ��ȭ

        // �� ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        buttons[NewGameButtonIndex].onClick.AddListener(NewGame);  // �� ���� ��ư
        buttons[ContinueButtonIndex].onClick.AddListener(Continue);  // �̾��ϱ� ��ư
        buttons[OptionButtonIndex].onClick.AddListener(EnterOption);  // �ɼ� �޴� ��ư
        buttons[ExitButtonIndex].onClick.AddListener(GameExit);   // ���� ���� ��ư

        // GameManager���� �̾��ϱ� ��ư ���¸� ������ ����
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            continueButton.interactable = gameManager.isContinueAvailable; // �̾��ϱ� ��ư�� Ȱ��ȭ ���� ����
        }
        else
        {
            continueButton.interactable = false; // GameManager�� ������ ��Ȱ��ȭ
            Debug.LogError("GameManager�� ã�� �� �����ϴ�.");
        }
    }

    void NewGame() // �� ���� ����
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // �� ���� ���� �޼ҵ� ȣ��
            continueButton.interactable = true; // �� ������ ����Ǿ����Ƿ� �̾��ϱ� ��ư Ȱ��ȭ
            SceneManager.LoadScene("LoadingScene"); // �ε� ������ ��ȯ
        }
        else
        {
            Debug.LogError("GameManager�� ã�� �� �����ϴ�!"); // GameManager�� ���� ��� ���� �α� ���
        }
    }

    void Continue()  // �̾��ϱ�
    {
        SceneManager.LoadScene("LoadingScene");  // �ε� �� �ε�
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
            Debug.Log("�÷��̾� ��ġ�� ȸ������ ����Ǿ����ϴ�: " + playerPosition + ", " + playerRotation);
        }

#if UNITY_EDITOR    // ����Ƽ �����Ϳ��� ���� ���� ��
        UnityEditor.EditorApplication.isPlaying = false; // �÷��� ��� ����
#else   // �� �� ���ø����̼��� ��
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    // �̾��ϱ� ��ư ���� ������Ʈ �޼���
    public void UpdateContinueButton(bool isContinueAvailable)
    {
        continueButton.interactable = isContinueAvailable; // ��ư�� interactable ���� ������Ʈ
    }
}
