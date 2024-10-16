using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerInputText : MonoBehaviour
{
    // 퀴즈의 정답 값
    int correctAnswer = 993;
    // 퀴즈 정답 프로퍼티 ( get 만 열어줌 )
    public int CorrectAnswer { get { return correctAnswer; } }
    // 현재 입력된 값 프로퍼티
    public string NowAnswer { get; set; }
}