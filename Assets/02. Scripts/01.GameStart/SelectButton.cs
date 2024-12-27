using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    Button[] buttons = null;

    public GameObject MainMenu;
    public GameObject TutorialMenu;
    public MainmenuButtons mainmenuButtons;

    private const int YesButtonIndex = 0;
    private const int NoButtonIndex = 1;
    private const int BackButtonIndex = 2;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    private void Start()
    {
        buttons[YesButtonIndex].onClick.AddListener(Yes);
        buttons[NoButtonIndex].onClick.AddListener(No);
        buttons[BackButtonIndex].onClick.AddListener(Back);
    }

    void Yes()
    {
        mainmenuButtons.creditButton.interactable = true; // �� ������ ����Ǿ����Ƿ� �̾��ϱ� ��ư Ȱ��ȭ
        GameManager.Instance.isTutorial = true;
        SceneManager.LoadScene("LoadingScene");
    }

    void No() // �� ���� ����
    {
        GameManager.Instance.isTutorial = false;

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // �� ���� ���� �޼ҵ� ȣ��
            mainmenuButtons.creditButton.interactable = true; // �� ������ ����Ǿ����Ƿ� �̾��ϱ� ��ư Ȱ��ȭ
            SceneManager.LoadScene("LoadingScene"); // �ε� ������ ��ȯ
        }
        else
        {

        }
    }

    void Back()
    {
        TutorialMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

}
