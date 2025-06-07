using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuButtons : MonoBehaviour
{
    Button[] buttons = null; // 버튼 배열

    public GameObject Mainmenu; // 메인 메뉴 게임 오브젝트
    public GameObject Optionmenu; // 옵션 메뉴 게임 오브젝트
    public GameObject TutorialMenu;
    public GameObject CreditMenu; //크레딧창
    public Button creditButton; // 이어하기 버튼 참조 추가

    private const int NewGameButtonIndex = 0; // 새 게임 버튼 인덱스
    private const int CreditButtonIndex = 1; // 이어하기 버튼 인덱스
    private const int OptionButtonIndex = 2; // 옵션 버튼 인덱스
    private const int ExitButtonIndex = 3; // 종료 버튼 인덱스

    private void Awake()
    {
        // 현재 오브젝트의 자식에서 버튼 컴포넌트를 가져와 배열에 저장
        buttons = GetComponentsInChildren<Button>();

        // 버튼 개수가 부족할 경우 에러 로그 출력
        if (buttons.Length < 4)
        {
            return;
        }

        // 이어하기 버튼 참조
        creditButton = buttons[CreditButtonIndex];

        languageEnglishCheck();
    }

    private void Start()
    {
        // 각 버튼에 클릭 이벤트 리스너 추가
        buttons[NewGameButtonIndex].onClick.AddListener(NewGame);  // 새 게임 버튼
        buttons[CreditButtonIndex].onClick.AddListener(Credit);  // 크레딧 버튼
        buttons[OptionButtonIndex].onClick.AddListener(EnterOption);  // 옵션 메뉴 버튼
        buttons[ExitButtonIndex].onClick.AddListener(GameExit);   // 게임 종료 버튼

        // GameManager에서 이어하기 버튼 상태를 가져와 설정
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            //continueButton.interactable = gameManager.isContinueAvailable; // 이어하기 버튼의 활성화 여부 설정
        }
        else
        {
            creditButton.interactable = false; // GameManager가 없으면 비활성화
        }


    }

    void NewGame() // 새 게임 시작
    {
        TutorialMenu.SetActive(true);
        Mainmenu.SetActive(false);
    }

    void Credit() //크레딧열기  // 이어하기
    {
        // GameManager.Instance.isTutorial = false;
        // SceneManager.LoadScene("LoadingScene");  // 로딩 씬 로드

        Mainmenu.SetActive(false);  // 메인 메뉴 비활성화
        CreditMenu.SetActive(true); //크레딧 메뉴 활성
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
        }

#if UNITY_EDITOR    // 유니티 에디터에서 실행 중일 때
        UnityEditor.EditorApplication.isPlaying = false; // 플레이 모드 종료
#else   // 그 외 애플리케이션일 때
        Application.Quit(); // 애플리케이션 종료
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

    public void languageEnglishCheck() //영어언어 체크 시 
    {   //게임매니저에 영어 설정 true 값을 넘김
        GameObject.Find("GameManager").GetComponent<GameManager>().languageKor = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().languageEng = true;
        //메인에 있는 텍스트 및 이미지를 영어로 교체 및 활성
        for (int i = 0; i < StartSceneKorean.Length; i++)
        {
            StartSceneKorean[i].SetActive(false);
        }
        for (int i = 0; i < StartSceneEnglish.Length; i++)
        {
            StartSceneEnglish[i].SetActive(true);
        }
    }
    public void languageKoreanCheck() //한국언어 체크 시 
    {   //게임매니저에 한국어 설정 true 값을 넘김
        GameObject.Find("GameManager").GetComponent<GameManager>().languageEng = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().languageKor = true;
        //메인에 있는 텍스트 및 이미지를 한국어로 교체 및 활성
        for (int i = 0; i < StartSceneEnglish.Length; i++)
        {
            StartSceneEnglish[i].SetActive(false);
        }
        for (int i = 0; i < StartSceneKorean.Length; i++)
        {
            StartSceneKorean[i].SetActive(true);
        }
       
    }

    // 이어하기 버튼 상태 업데이트 메서드
    public void UpdateContinueButton(bool isContinueAvailable)
    {
        //continueButton.interactable = isContinueAvailable; // 버튼의 interactable 상태 업데이트
    }
}
