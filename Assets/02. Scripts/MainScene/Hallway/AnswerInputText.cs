using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerInputText : MonoBehaviour
{
    // ������ ���� ��
    int correctAnswer = 993;
    // ���� ���� ������Ƽ ( get �� ������ )
    public int CorrectAnswer { get { return correctAnswer; } }
    // ���� �Էµ� �� ������Ƽ
    public string NowAnswer { get; set; }

    private TextMeshProUGUI nowText;

    private void Awake()
    {
        nowText = GetComponent<TextMeshProUGUI>();
        NowAnswer = "";
    }

    private void Update()
    {
        nowText.text = NowAnswer;
    }
}