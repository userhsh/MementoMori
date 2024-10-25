using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuButtons : MonoBehaviour
{
    Button[] buttons = null;
    private GameObject Mainmenu;
    private GameObject Optionmenu;

    private Button continueButton; // �̾��ϱ� ��ư ���� �߰�

    private void Awake()
    {
        Mainmenu = GameObject.Find("Main menu");
        Optionmenu = GameObject.Find("Option menu");

        buttons = GetComponentsInChildren<Button>();    // ��ư�� �迭��

        if (buttons.Length > 1)
        {
            // �̾��ϱ� ��ư ����
            continueButton = buttons[1]; // �̾��ϱ� ��ư
            Debug.Log("Continue Button Found.");
        }
        else
        {
            Debug.LogError("Continue Button�� ã�� �� �����ϴ�.");
        }
    }

    private void Start()
    {
        Optionmenu.gameObject.SetActive(false);

        buttons[0].onClick.AddListener(NewGame);  // 1��° ��ư ������ �� �Լ�ȣ��
        buttons[1].onClick.AddListener(Continue);  // 2��° ��ư ������ �� �Լ�ȣ��
        buttons[2].onClick.AddListener(EnterOption);  // 3��° ��ư ������ �� �Լ�ȣ��
        buttons[3].onClick.AddListener(GameExit);   // 4��° ��ư ������ �� �Լ�ȣ��

        // �̾��ϱ� ��ư ���¸� GameManager���� �ҷ��� ����
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // �̾��ϱ� ��ư Ȱ��ȭ ���� Ȯ��
            Debug.Log("Continue Button State: " + gameManager.isContinueAvailable);

            // �̾��ϱ� ��ư�� interactable ���� ����
            continueButton.interactable = gameManager.isContinueAvailable;
        }
        else
        {
            // GameManager�� ������ ��Ȱ��ȭ
            continueButton.interactable = false;
            Debug.LogError("GameManager�� ã�� �� �����ϴ�.");
        }

        Debug.Log("GameManager isContinueAvailable: " + gameManager.isContinueAvailable);

    }

    void NewGame() // �� ����
    {
        Debug.Log("�� ���� ����");
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // �� ���� ���� �޼ҵ� ȣ��

            // �� ������ ����Ǿ����Ƿ� �̾��ϱ� ��ư Ȱ��ȭ
            continueButton.interactable = true;

            SceneManager.LoadScene("LoadingScene"); // �ε� ������ ��ȯ
        }
        else
        {
            Debug.LogError("GameManager�� ã�� �� �����ϴ�!");
        }
    }

    void Continue()  // �̾��ϱ� 
    {
        SceneManager.LoadScene("LoadingScene");  // �ε��� �ε�
    }

    void EnterOption()
    {
        Mainmenu.SetActive(false);  // ���θ޴� ��Ȱ��ȭ
        Optionmenu.SetActive(true); // �ɼǸ޴� Ȱ��ȭ
    }

    void GameExit()
    {
        // �÷��̾��� ���� ��ġ ����
        PlayerController playerController = FindObjectOfType<PlayerController>();
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (playerController != null && gameManager != null)
        {
            // ���� �÷��̾� ��ġ ����
            gameManager.SaveGameData(playerController.transform.position);
            Debug.Log("�÷��̾� ��ġ�� ����Ǿ����ϴ�: " + playerController.transform.position);
        }

#if UNITY_EDITOR    // ����Ƽ �������� �� ���� ���
        UnityEditor.EditorApplication.isPlaying = false;
#else   // �� �� ���ø����̼��� �� ��������
        Application.Quit();
#endif
    }

    public void UpdateContinueButton(bool isContinueAvailable)
    {
        continueButton.interactable = isContinueAvailable;
        Debug.Log("Continue button updated to: " + isContinueAvailable);
    }
}