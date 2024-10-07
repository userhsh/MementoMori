using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour
{
    QuizWindow quizWindow = null;
    AnswerWindow answerWindow = null;

    Keyboard keyboard = null; //키보드 버튼 배열 담아둔 스크립트 불러올 곳
    TextMeshProUGUI passwordText = null; //출력용 비밀번호 텍스트 > ****
    WrongImage wrongImage = null; //오답에서 엔터 누르면 출력할 이미지

    string password = ""; //정답과 비교용 실제 텍스트
    string correctPassword = "3752"; //패스워드 정답
    string quizAnswer = "3"; //퀴즈 정답

    public void ComputerUIInit()
    {
        quizWindow = GetComponentInChildren<QuizWindow>();
        quizWindow.gameObject.SetActive(false);

        answerWindow = GetComponentInChildren<AnswerWindow>();
        answerWindow.gameObject.SetActive(false);

        keyboard = GetComponentInChildren<Keyboard>();
        passwordText = GetComponentInChildren<TextMeshProUGUI>();
        wrongImage = GetComponentInChildren<WrongImage>();
        keyboard.KeyboardButtonInit();

        wrongImage.gameObject.SetActive(false); //오답이미지 꺼둠

        foreach (Button _button in keyboard.KeyboardButton) //각 버튼들마다 클릭이벤트 설정
        {
            if (_button.name == "DEL")
            {
                _button.onClick.AddListener(() => DeletePassword()); //한자리 지움
            }
            else if (_button.name == "ENTER")
            {
                _button.onClick.AddListener(() => CheckPassword()); //비밀번호 판별
            }
            else
            {
                _button.onClick.AddListener(() => GetNumber(_button.name)); //숫자입력 받음
            }
        }
    }

    private void GetNumber(string _buttonName)
    {
        if (password.Length >= 4) return; //최대 4자리 넘지않도록 > 넘으면 리턴
        password += _buttonName; //판별할 값에 입력숫자 더해줌
        DisplayText(); //* 갯수 업데이트
        print(password);
    }

    private void DeletePassword() // DEL 눌렀을때 
    {
        if (password.Length > 0) // 비밀번호가 0보다 크면 삭제
        {
            password = password.Substring(0, password.Length - 1);
            DisplayText();
            print(password);
        }
    }

    private void CheckPassword()
    {
        if (password.Length == 0) return;

        if (password == correctPassword)
        {
            print("CorrectPassword");
            password = "";
            // 지금 윈도우 끄고 새 윈도우 켤것
            quizWindow.gameObject.SetActive(true); //퀴즈화면 띄움

            if(password == quizAnswer)
            {
                answerWindow.gameObject.SetActive(true);
            }
        }
        else
        {
            wrongImage.gameObject.SetActive(true);
            Invoke("OffWrongImage", 1f);
            ClearPassword();
        }
    }

    private void OffWrongImage()
    {
        wrongImage.gameObject.SetActive(false);
    }

    private void ClearPassword()
    {
        password = "";
        DisplayText();
    }

    private void DisplayText()
    {
        if (password.Length == 0)
        {
            passwordText.text = "";
        }
        else
        {
            passwordText.text = new string('*', password.Length);
        }
    }
}