using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuButtons : MonoBehaviour
{
    Button[] buttons = null; // 버튼 배열
    private GameObject Mainmenu; // 메인 메뉴 게임 오브젝트
    private GameObject Optionmenu; // 옵션 메뉴 게임 오브젝트

    private Button continueButton; // 이어하기 버튼 참조 추가

    private const int NewGameButtonIndex = 0; // 새 게임 버튼 인덱스
    private const int ContinueButtonIndex = 1; // 이어하기 버튼 인덱스
    private const int OptionButtonIndex = 2; // 옵션 버튼 인덱스
    private const int ExitButtonIndex = 3; // 종료 버튼 인덱스

    private void Awake()
    {
        // 메인 메뉴와 옵션 메뉴 게임 오브젝트 찾기
        Mainmenu = GameObject.Find("Main menu");
        Optionmenu = GameObject.Find("Option menu");

        // 현재 오브젝트의 자식에서 버튼 컴포넌트를 가져와 배열에 저장
        buttons = GetComponentsInChildren<Button>();

        // 버튼 개수가 부족할 경우 에러 로그 출력
        if (buttons.Length < 4)
        {
            Debug.LogError("버튼 개수가 부족합니다. 현재 버튼 개수: " + buttons.Length);
            return;
        }

        // 이어하기 버튼 참조
        continueButton = buttons[ContinueButtonIndex];
    }

    private void Start()
    {
        Optionmenu.SetActive(false); // 옵션 메뉴 비활성화

        // 각 버튼에 클릭 이벤트 리스너 추가
        buttons[NewGameButtonIndex].onClick.AddListener(NewGame);  // 새 게임 버튼
        buttons[ContinueButtonIndex].onClick.AddListener(Continue);  // 이어하기 버튼
        buttons[OptionButtonIndex].onClick.AddListener(EnterOption);  // 옵션 메뉴 버튼
        buttons[ExitButtonIndex].onClick.AddListener(GameExit);   // 게임 종료 버튼

        // GameManager에서 이어하기 버튼 상태를 가져와 설정
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            continueButton.interactable = gameManager.isContinueAvailable; // 이어하기 버튼의 활성화 여부 설정
        }
        else
        {
            continueButton.interactable = false; // GameManager가 없으면 비활성화
            Debug.LogError("GameManager를 찾을 수 없습니다.");
        }
    }

    void NewGame() // 새 게임 시작
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // 새 게임 시작 메소드 호출
            continueButton.interactable = true; // 새 게임이 저장되었으므로 이어하기 버튼 활성화
            SceneManager.LoadScene("LoadingScene"); // 로딩 씬으로 전환
        }
        else
        {
            Debug.LogError("GameManager를 찾을 수 없습니다!"); // GameManager가 없을 경우 에러 로그 출력
        }
    }

    void Continue()  // 이어하기
    {
        SceneManager.LoadScene("LoadingScene");  // 로딩 씬 로드
    }

    void EnterOption() // 옵션 메뉴로 전환
    {
        Mainmenu.SetActive(false);  // 메인 메뉴 비활성화
        Optionmenu.SetActive(true); // 옵션 메뉴 활성화
    }

    void GameExit() // 게임 종료 처리
    {
        // 현재 씬에서 플레이어와 GameManager를 찾음
        PlayerController playerController = FindObjectOfType<PlayerController>();
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (playerController != null && gameManager != null)
        {
            // 플레이어의 위치와 회전값을 저장
            Vector3 playerPosition = playerController.transform.position; // 플레이어 위치
            Vector3 playerRotation = playerController.transform.rotation.eulerAngles; // 플레이어 회전값

            gameManager.SaveGameData(playerPosition, playerRotation); // 플레이어 위치와 회전값 저장
            Debug.Log("플레이어 위치와 회전값이 저장되었습니다: " + playerPosition + ", " + playerRotation);
        }

#if UNITY_EDITOR    // 유니티 에디터에서 실행 중일 때
        UnityEditor.EditorApplication.isPlaying = false; // 플레이 모드 종료
#else   // 그 외 애플리케이션일 때
        Application.Quit(); // 애플리케이션 종료
#endif
    }

    // 이어하기 버튼 상태 업데이트 메서드
    public void UpdateContinueButton(bool isContinueAvailable)
    {
        continueButton.interactable = isContinueAvailable; // 버튼의 interactable 상태 업데이트
    }
}
