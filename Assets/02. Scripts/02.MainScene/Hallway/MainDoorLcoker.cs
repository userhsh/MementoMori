using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainDoorLcoker : MonoBehaviour
{
    // 모든 버튼 담을 변수 선언 (0 ~ 3 위 화살표 버튼, 4 ~ 7 아래 화살표 버튼, 8 open 버튼)
    Button[] arrowButtons = null;
    // 텍스트 담을 변수 선언
    TextMeshProUGUI[] passwordTexts = null;
    // 실제 값을 바꿔줄 int 배열 선언
    int[] password = new int[4] { 0, 0, 0, 0 };
    // 정답 비밀번호 문자열
    string correctPassword = "1022";
    // 현재 입력된 비밀번호 문자열
    string nowPassword = string.Empty;
    // 게임 클리어 여부
    bool isGameclear = false;

    public UIManager uiManager = null;

    private void Awake()
    {
        MainDoorLockerInit();
    }

    // 현관문 잠금장치 Init 메서드
    private void MainDoorLockerInit()
    {
        arrowButtons = GetComponentsInChildren<Button>();
        passwordTexts = GetComponentsInChildren<TextMeshProUGUI>();

        ButtonsInit();
    }

    // 버튼 Init 메서드
    private void ButtonsInit()
    {
        // 모든 버튼에 대해서
        for (int i = 0; i < arrowButtons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(0));
                    break;
                case 1:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(1));
                    break;
                case 2:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(2));
                    break;
                case 3:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(3));
                    break;
                case 4:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(0));
                    break;
                case 5:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(1));
                    break;
                case 6:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(2));
                    break;
                case 7:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(3));
                    break;
                case 8:
                    arrowButtons[i].onClick.AddListener(PasswordCheck);
                    break;
            }
        }
    }

    // 위 버튼 눌렀을 때 메서드
    // password의 인덱스가 버튼의 _value와 같은 변수만 변경
    private void UpArrowButton(int _value)
    {
        // 1 증가
        password[_value]++;

        // 만약 password 값이 10이상이 되면
        if (password[_value] >= 10)
        {
            // 10을 빼주기 
            password[_value] -= 10;
        }
        // 텍스트에 전달
        passwordTexts[_value].text = password[_value].ToString();
    }

    // 아래 버튼 눌렀을 때 메서드
    // password의 인덱스가 버튼의 _value와 같은 변수만 변경
    private void DownArrowButton(int _value)
    {
        // 1 감소
        password[_value]--;

        // 만약 password 값이 0미만이 되면
        if (password[_value] < 0)
        {
            password[_value] += 10;
        }
        // 텍스트에 전달
        passwordTexts[_value].text = password[_value].ToString();
    }

    private void PasswordCheck()
    {
        nowPassword = "";

        for (int i = 0; i < password.Length; i++)
        {
            nowPassword += password[i];
        }

        if (correctPassword == nowPassword)
        {
            isGameclear = true;
            Destroy(this.gameObject);

            ChangeEndingScene();
        }
        else
        {
            isGameclear = false;
        }
    }

    private void ChangeEndingScene()
    {
        if (!isGameclear) return;

        if (uiManager.IsAllCollection)
        {
            SceneManager.LoadScene("TrueEndingScene");
        }
        else
        {
            SceneManager.LoadScene("NomalEndingScene");
        }
    }
}