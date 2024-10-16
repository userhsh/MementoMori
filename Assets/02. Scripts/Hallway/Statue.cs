using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statue : MonoBehaviour, IInteractable
{
    // ���� ���� ������ ���� ����
    HallwayBox hallwayBox = null;

    // ���� â ������ ���� ����
    Canvas statueQuizCanvas = null;
    // ���� ���� �Է� ���� ��ư�� ���� ���� ����
    StatueQuizButton[] quizButtons = null;
    // �Է� �� ǥ���� �ؽ�Ʈ ���� ����
    AnswerInputText answerInputText = null;
    // ���� â ������ Ȯ���� ���� ����
    bool isQuizOpen = false;
    // ������ ������ ������� Ȯ���� ���� ����
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
        // ������ ������ ��������
        hallwayBox = GetComponentInChildren<HallwayBox>();
        hallwayBox.HallwayBoxinit();

        statueQuizCanvas = GetComponentInChildren<Canvas>();
        answerInputText = GetComponentInChildren<AnswerInputText>();
        quizButtons = GetComponentsInChildren<StatueQuizButton>();
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
        for (int i = 0; i < quizButtons.Length; i++)
        {
            if (i < 10)
            {
                // ��ư �ε����� 0 ~ 9 �� ��ư�� AddAnswer ����
                quizButtons[i].GetComponent<Button>().onClick.AddListener(() => AddAnswer(i));
            }
            else if (i == 10)
            {
                // ��ư �ε����� 10 �� ��ư�� DelAnswer ����
                quizButtons[i].GetComponent<Button>().onClick.AddListener(DelAnswer);
            }
            else
            {
                // ��ư �ε����� 11 �� ��ư�� CheckAnswer ����
                quizButtons[i].GetComponent<Button>().onClick.AddListener(CheckAnswer);
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
            isQuizClear = true;
        }
        else
        {
            // Ŭ���� ����
            isQuizClear = false;
        }
    }

    // ���� ���� �޼���
    private void DelAnswer()
    {
        // ���� ���� ũ�Ⱑ 0�� �ƴ϶�� (= �ϳ��� �Է��� �޾Ҵٸ�)
        if (answerInputText.NowAnswer.Length != 0)
        {
            // ������ �Է� �� ����
            answerInputText.NowAnswer.Substring(0, answerInputText.NowAnswer.Length - 1);
        }
    }

    // ���� �Է� �޼���
    private void AddAnswer(int _value)
    {
        // ���� ���� ũ�Ⱑ 3���� ���� �� (= �Է°��� 2������ ���� ��)
        if (answerInputText.NowAnswer.Length < 3)
        {
            // _value�� ������ �Է�
            answerInputText.NowAnswer += _value.ToString();
        }
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