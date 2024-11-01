using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Statue : MonoBehaviour, IInteractable
{
    // ���� ���� ������ ���� ����
    HallwayBox hallwayBox = null;

    // ���� â ������ ���� ����
    public Canvas statueQuizCanvas = null;
    // ���� ���� �Է� ���� ��ư�� ���� ���� ����
    Button[] quizButtons = null;
    // �Է� �� ǥ���� �ؽ�Ʈ ���� ����
    AnswerInputText answerInputText = null;
    // ���� â ������ Ȯ���� ���� ����
    bool isQuizOpen = false;
    // ������ ������ ������� Ȯ���� ���� ����
    bool isQuizClear = false;

    AudioSource audioSource = null;
    [SerializeField]
    AudioClip correctclip = null;
    [SerializeField]
    AudioClip unCorrectclip = null;

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
        // ������ ������ ��������
        hallwayBox = GetComponentInChildren<HallwayBox>();
        hallwayBox.HallwayBoxinit();

        answerInputText = GetComponentInChildren<AnswerInputText>();

        quizButtons = GetComponentsInChildren<Button>();

        audioSource = GetComponent<AudioSource>();

        ButtonsInit();

        // ó���� ����â ���α�
        statueQuizCanvas.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if (isQuizClear) return;
        // ���ͷ����� �۵��� �� ���� isQuizOpen ���� �ٲ��ֱ�
        isQuizOpen = !isQuizOpen;
        // isQuizOpen ������ ���� ���� â �Ѱ� ����
        statueQuizCanvas.gameObject.SetActive(isQuizOpen);
    }

    // ��ư�� �޼��� ����
    private void ButtonsInit()
    {
        foreach (Button _button in quizButtons) 
        {
            if (_button.name == "Del")
            {
                _button.onClick.AddListener(() => DelAnswer()); //���ڸ� ����
            }
            else if (_button.name == "Enter")
            {
                _button.onClick.AddListener(() => CheckAnswer()); //��й�ȣ �Ǻ�
            }
            else
            {
                _button.onClick.AddListener(() => AddAnswer(int.Parse(_button.name))); //�����Է� ����
            }
        }
    }

    // �Է� ���� �������� Ȯ���ϴ� �޼���
    private void CheckAnswer()
    {
        // �Էµ� ���� �����̶� ������
        if (answerInputText.CorrectAnswer.ToString() == answerInputText.NowAnswer)
        {
            // Ŭ���� ����
            audioSource.PlayOneShot(correctclip);
            isQuizClear = true;
        }
        else
        {
            // Ŭ���� ����
            audioSource.PlayOneShot(unCorrectclip);
            isQuizClear = false;
            answerInputText.NowAnswer = "";
        }
    }

    // ���� ���� �޼���
    private void DelAnswer()
    {
        if (answerInputText.NowAnswer.Length == 0) return;

        answerInputText.NowAnswer = answerInputText.NowAnswer.Substring(0, answerInputText.NowAnswer.Length - 1);
    }

    // ���� �Է� �޼���
    private void AddAnswer(int _value)
    {
        if (answerInputText.NowAnswer.Length >= 3) return;
            
        answerInputText.NowAnswer += _value;
    }

    // ���� ���� �ڷ�ƾ
    IEnumerator OpenHallwayBox()
    {
        // ������ ���� ���°� �ƴ϶��
        while (!isQuizClear)
        {
            // �� ������ ���
            yield return null;
        }
        // ������ ����ٸ�
        // ����â �ݱ�
        statueQuizCanvas.gameObject.SetActive(false);

        
        // ���� ����
        hallwayBox.HallwayBoxAnimator.SetTrigger("IsOpen");
    }
}