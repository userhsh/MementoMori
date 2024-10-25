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


    private void Awake()
    {
        Mainmenu = GameObject.Find("Main menu");
        Optionmenu = GameObject.Find("Option menu");

        buttons = GetComponentsInChildren<Button>();    // 버튼을 배열로
    }

    private void Start()
    {
        Optionmenu.gameObject.SetActive(false);

        buttons[0].onClick.AddListener(NewGame);  // 1번째 버튼 눌렀을 때 함수호출
        buttons[1].onClick.AddListener(Continue);  // 2번째 버튼 눌렀을 때 함수호출
        buttons[2].onClick.AddListener(EnterOption);  // 3번째 버튼 눌렀을 때 함수호출
        buttons[3].onClick.AddListener(GameExit);   // 4번째 버튼 눌렀을 때 함수호출
    }

    void NewGame() // 새 게임
    {
        Debug.Log("새 게임 시작");
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // 새 게임 시작 메소드 호출
            SceneManager.LoadScene("LoadingScene"); // 로딩 씬으로 전환
        }
        else
        {
            Debug.LogError("GameManager를 찾을 수 없습니다!");
        }
    }

    void Continue()  // 이어하기 
    {
        SceneManager.LoadScene("LoadingScene");  // 로딩씬 로드
    }

    void EnterOption()
    {
        Mainmenu.SetActive(false);  // 메인메뉴 비활성화
        Optionmenu.SetActive(true); // 옵션메뉴 활성화
    }

    void GameExit()
    {
        // 플레이어의 현재 위치 저장
        PlayerController playerController = FindObjectOfType<PlayerController>();
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (playerController != null && gameManager != null)
        {
            // 현재 플레이어 위치 저장
            gameManager.SaveGameData(playerController.transform.position);
            Debug.Log("플레이어 위치가 저장되었습니다: " + playerController.transform.position);
        }
        else
        {
            Debug.LogError("PlayerController 또는 GameManager를 찾을 수 없습니다!");
        }

#if UNITY_EDITOR    // 유니티 에디터일 때 실행 취소
        UnityEditor.EditorApplication.isPlaying = false;
#else   // 그 외 애플리케이션일 때 게임종료
        Application.Quit();
#endif
    }
}