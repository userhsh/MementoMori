using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLogoEvent : MonoBehaviour
{
    TLeftController TleftController;
    MainmenuButtons mainmenuButtons;
    public MainmenuButtons MainmenuButtons;

    private void Awake()
    {
        mainmenuButtons = GetComponent<MainmenuButtons>();
        TleftController = GameObject.FindWithTag("PLAYER").GetComponentInChildren<TLeftController>();
    }

    public void Warp() //임시적으로 클리어공간 이동, 컨트롤러 표시X
    {
        GameObject.Find("Player").transform.position = new Vector3(0, -1.5f, 0);
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
    }

    public void NextScene()
    {
        TleftController.RemoveEvent(); //펑션 삭제
        GameManager.Instance.isTutorial = false;

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // 새 게임 시작 메소드 호출
          
        }
        else
        {
            Debug.LogError("GameManager를 찾을 수 없습니다!"); // GameManager가 없을 경우 에러 로그 출력
        }

        SceneManager.LoadScene("LoadingScene");
    }
}
