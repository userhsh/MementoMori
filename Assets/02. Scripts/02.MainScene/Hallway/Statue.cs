using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Statue : MonoBehaviour, IInteractable
{
    // 복도 상자 가져올 변수 선언
    HallwayBox hallwayBox = null;

    public GameObject boxDoor;
    public GameObject shutterBoxTriggerRayOff;

    // 퀴즈 창 가져올 변수 선언
    public GameObject quizBlock = null;
    // 퀴즈 정답 입력 받을 버튼들 담을 변수 선언
    Button[] quizButtons = null;
    // 입력 값 표시할 텍스트 변수 선언
    AnswerInputText answerInputText = null;
    // 퀴즈 창 열건지 확인할 변수 선언
    bool isQuizOpen = false;
    // 퀴즈의 정답을 맞췄는지 확인할 변수 선언
    bool isQuizClear = false;

    AudioSource audioSource = null;
    [SerializeField]
    AudioClip correctclip = null;
    [SerializeField]
    AudioClip unCorrectclip = null;
    [SerializeField]
    AudioClip buttonSelectclip = null;
    [SerializeField]
    AudioClip correctPanelclip = null;

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

        answerInputText = GetComponentInChildren<AnswerInputText>();

        quizButtons = GetComponentsInChildren<Button>();

        audioSource = GetComponent<AudioSource>();

        ButtonsInit();

        // 처음에 퀴즈창 꺼두기
        quizBlock.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if (isQuizClear) return;
        if (isQuizOpen) return;
        // isQuizOpen을 true로 변경
        isQuizOpen = true;
        // isQuizOpen 상태의 따라 퀴즈 창 켜고 끄기
        quizBlock.gameObject.SetActive(isQuizOpen);
        audioSource.PlayOneShot(correctPanelclip);
    }

    // 버튼의 메서드 매핑
    private void ButtonsInit()
    {
        foreach (Button _button in quizButtons) 
        {
            if (_button.name == "Del")
            {
                _button.onClick.AddListener(() => DelAnswer()); //한자리 지움
            }
            else if (_button.name == "Enter")
            {
                _button.onClick.AddListener(() => CheckAnswer()); //비밀번호 판별
            }
            else
            {
                _button.onClick.AddListener(() => AddAnswer(int.Parse(_button.name))); //숫자입력 받음
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
            audioSource.PlayOneShot(correctclip);
            isQuizClear = true;
        }
        else
        {
            // 클리어 실패
            audioSource.PlayOneShot(unCorrectclip);
            isQuizClear = false;
            answerInputText.NowAnswer = "";
        }
    }

    // 정답 제거 메서드
    private void DelAnswer()
    {
        if (answerInputText.NowAnswer.Length == 0) return;

        audioSource.PlayOneShot(buttonSelectclip);
        answerInputText.NowAnswer = answerInputText.NowAnswer.Substring(0, answerInputText.NowAnswer.Length - 1);
    }

    // 정답 입력 메서드
    private void AddAnswer(int _value)
    {
        if (answerInputText.NowAnswer.Length >= 3) return;

        audioSource.PlayOneShot(buttonSelectclip);
        answerInputText.NowAnswer += _value;
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
        quizBlock.gameObject.SetActive(false);
        shutterBoxTriggerRayOff.SetActive(false);
        Destroy(boxDoor.gameObject);

        // 상자 오픈
        //hallwayBox.HallwayBoxAnimator.SetTrigger("IsOpen");
    }
}