using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerInputText : MonoBehaviour
{
    // ������ ���� ��
    int correctAnswer = 993;
    // ���� ���� ������Ƽ ( get �� ������ )
    public int CorrectAnswer { get { return correctAnswer; } }
    // ���� �Էµ� �� ������Ƽ
    public string NowAnswer { get; set; }
}