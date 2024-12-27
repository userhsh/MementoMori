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
        mainmenuButtons.creditButton.interactable = true; // 새 게임이 저장되었으므로 이어하기 버튼 활성화
        GameManager.Instance.isTutorial = true;
        SceneManager.LoadScene("LoadingScene");
    }

    void No() // 새 게임 시작
    {
        GameManager.Instance.isTutorial = false;

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // 새 게임 시작 메소드 호출
            mainmenuButtons.creditButton.interactable = true; // 새 게임이 저장되었으므로 이어하기 버튼 활성화
            SceneManager.LoadScene("LoadingScene"); // 로딩 씬으로 전환
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
