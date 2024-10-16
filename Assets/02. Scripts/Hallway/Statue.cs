using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statue : MonoBehaviour, IInteractable
{
    // 복도 상자 가져올 변수 선언
    HallwayBox hallwayBox = null;

    // 퀴즈 창 가져올 변수 선언
    Canvas statueQuizCanvas = null;
    // 퀴즈 정답 입력 받을 버튼들 담을 변수 선언
    StatueQuizButton[] quizButtons = null;
    // 입력 값 표시할 텍스트 변수 선언
    AnswerInputText answerInputText = null;
    // 퀴즈 창 열건지 확인할 변수 선언
    bool isQuizOpen = false;
    // 퀴즈의 정답을 맞췄는지 확인할 변수 선언
    bool isQuizClear = false;

    private void Awake()
    {
        StatueInit();
    }

    private void OnEnable()
    {
        StartCoroutine(OpenHallwayBox());
    }

    private void OnDisable()
    {
        StopCoroutine(OpenHallwayBox());
    }

    private void StatueInit()
    {
        // 선언한 변수들 가져오기
        hallwayBox = GetComponentInChildren<HallwayBox>();
        hallwayBox.HallwayBoxinit();

        statueQuizCanvas = GetComponentInChildren<Canvas>();
        answerInputText = GetComponentInChildren<AnswerInputText>();
        quizButtons = GetComponentsInChildren<StatueQuizButton>();
        ButtonsInit();

        // 처음에 퀴즈창 꺼두기
        statueQuizCanvas.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if (isQuizClear) return;
        // 인터렉션이 작동할 때 마다 isQuizOpen 상태 바꿔주기
        isQuizOpen = !isQuizOpen;
        // isQuizOpen 상태의 따라 퀴즈 창 켜고 끄기
        statueQuizCanvas.gameObject.SetActive(isQuizOpen);
    }

    // 버튼의 메서드 매핑
    private void ButtonsInit()
    {
        for (int i = 0; i < quizButtons.Length; i++)
        {
            if (i < 10)
            {
                // 버튼 인덱스가 0 ~ 9 인 버튼은 AddAnswer 매핑
                quizButtons[i].GetComponent<Button>().onClick.AddListener(() => AddAnswer(i));
            }
            else if (i == 10)
            {
                // 버튼 인덱스가 10 인 버튼은 DelAnswer 매핑
                quizButtons[i].GetComponent<Button>().onClick.AddListener(DelAnswer);
            }
            else
            {
                // 버튼 인덱스가 11 인 버튼은 CheckAnswer 매핑
                quizButtons[i].GetComponent<Button>().onClick.AddListener(CheckAnswer);
            }
        }
    }

    // 입력 값이 정답인지 확인하는 메서드
    private void CheckAnswer()
    {
        // 입력된 값이 정답이랑 같으면
        if (answerInputText.CorrectAnswer.ToString() == answerInputText.NowAnswer)
        {
            // 클리어 성공
            isQuizClear = true;
        }
        else
        {
            // 클리어 실패
            isQuizClear = false;
        }
    }

    // 정답 제거 메서드
    private void DelAnswer()
    {
        // 현재 답의 크기가 0이 아니라면 (= 하나라도 입력을 받았다면)
        if (answerInputText.NowAnswer.Length != 0)
        {
            // 마지막 입력 값 제거
            answerInputText.NowAnswer.Substring(0, answerInputText.NowAnswer.Length - 1);
        }
    }

    // 정답 입력 메서드
    private void AddAnswer(int _value)
    {
        // 현재 답의 크기가 3보다 작을 때 (= 입력값이 2개보다 작을 때)
        if (answerInputText.NowAnswer.Length < 3)
        {
            // _value를 갑으로 입력
            answerInputText.NowAnswer += _value.ToString();
        }
    }

    // 상자 오픈 코루틴
    IEnumerator OpenHallwayBox()
    {
        // 정답을 맞춘 상태가 아니라면
        while (!isQuizClear)
        {
            // 매 프레임 대기
            yield return null;
        }
        // 정답을 맞췄다면
        // 퀴즈창 닫기
        statueQuizCanvas.gameObject.SetActive(false);
        // 상자 오픈
        hallwayBox.HallwayBoxAnimator.SetTrigger("IsOpen");
    }
}