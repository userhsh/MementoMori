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

        buttons[0].onClick.AddListener(Continue);  // 1번째 버튼 눌렀을 때 함수호출
        buttons[1].onClick.AddListener(ChangeMorgueScene);  // 2번째 버튼 눌렀을 때 함수호출
        buttons[2].onClick.AddListener(EnterOption);  // 3번째 버튼 눌렀을 때 함수호출
        buttons[3].onClick.AddListener(GameExit);   // 4번째 버튼 눌렀을 때 함수호출
    }

    void Continue()
    {
        Debug.Log("저장된 부분으로 씬 이동");
    }

    void ChangeMorgueScene()    
    {
        SceneManager.LoadScene("MorgueScene");  // 시체안치실 씬 로드
    }

    void EnterOption()
    {
        Mainmenu.SetActive(false);  // 메인메뉴 비활성화
        Optionmenu.SetActive(true); // 옵션메뉴 활성화
    }

    void GameExit()
    {
        #if UNITY_EDITOR    // 유니티 에디터일 때 실행 취소
            UnityEditor.EditorApplication.isPlaying = false;
        #else   // 그 외 애플리케이션일 때 게임종료
            Application.Quit();
        #endif
    }
}