using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Groove2 : MonoBehaviour
{
    public GameObject[] Numbers; // 숫자 오브젝트 배열
    public bool CorrectB = false; // 숫자 1이 올바른지 여부
    public GameObject SuccessText; // 성공 텍스트 UI
    public GameObject Password; // 비밀번호 오브젝트
    public bool IsWrong = false; // 잘못된 숫자 입력 여부

    // 숫자 1과 충돌 시 올바른 입력 체크
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1번 숫자 확인
        {
            CorrectB = true; // 정답 상태
        }
        else
        {
            // "SpotLight" 외 다른 오브젝트와 충돌 시 잘못된 입력
            if (!other.CompareTag("SpotLight"))
            {
                IsWrong = true;
            }
        }
    }

    // 숫자 1에서 벗어났을 때 상태 리셋
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1번 숫자 체크
        {
            CorrectB = false; // 정답 상태 리셋
        }
        else
        {
            // "SpotLight" 외 다른 오브젝트에서 벗어났을 때 잘못된 입력 리셋
            if (!other.CompareTag("SpotLight"))
            {
                IsWrong = false;
            }
        }
    }
}
