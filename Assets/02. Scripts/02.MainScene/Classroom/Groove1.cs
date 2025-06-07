using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Groove1 : MonoBehaviour
{
    public GameObject[] Numbers;  // 숫자 오브젝트 배열
    public bool CorrectA = false; // 숫자 9가 올바른지 여부
    public GameObject SuccessText; // 성공 텍스트 UI
    public Groove2 groove2; // Groove2 객체 참조
    public GameObject Password; // 비밀번호 오브젝트
    public bool isFog = false; // 안개 상태 체크
    public AudioSource audioSource; // 오디오 소스
    public AudioClip[] audioClip; // 오디오 클립 배열
    public bool isWrong = false; // 잘못된 숫자 입력 여부

    // 초기화 시 오디오 소스 컴포넌트 할당
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 게임 시작 시, 정답 검증 코루틴 시작
    private void Start()
    {
        StartCoroutine(Correct());
    }

    // 숫자 오브젝트와 충돌 시, 올바른 숫자 체크
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Numbers[8]) // 9번 숫자 확인
        {
            CorrectA = true; // 정답
        }
        else
        {
            // "SpotLight"가 아닌 다른 오브젝트와 충돌 시 잘못된 입력
            if (!other.CompareTag("SpotLight"))
            {
                isWrong = true;
            }
        }
    }

    // 숫자 오브젝트에서 벗어났을 때, 상태 리셋
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Numbers[8]) // 9번 숫자 체크
        {
            CorrectA = false; // 정답 상태 리셋
        }
        else
        {
            // "SpotLight"가 아닌 다른 오브젝트에서 벗어났을 때 잘못된 입력 리셋
            if (!other.CompareTag("SpotLight"))
            {
                isWrong = false;
            }
        }
    }

    // 정답 확인 후 성공 처리
    private IEnumerator Correct()
    {
        // 9번 또는 1번 숫자 오브젝트의 콜라이더가 활성화되지 않으면 계속 기다림
        while (Numbers[8].GetComponent<Collider>().enabled == true || Numbers[0].GetComponent<Collider>().enabled == true)
        {
            yield return null;
        }

        SuccessText.SetActive(true); // 성공 텍스트 표시
        Password.SetActive(true); // 비밀번호 오브젝트 활성화
        isFog = true; // 안개 상태 활성화

        Invoke("CorrectTalkText", 3); // 3초 후 "증기가 멈춘 것 같다." 대사 실행
    }

    // 성공 후 대사 실행
    void CorrectTalkText()
    {
        // UI에서 대사 처리
        if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
        {
            StartCoroutine(GameObject.Find("PlayerUI").GetComponent<UITalk>().InteractionTalk("The steam stopped."));
        }
        else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
        {
            StartCoroutine(GameObject.Find("PlayerUI").GetComponent<UITalk>().InteractionTalk("증기가 멈춘 것 같다."));
        }
      
    }
}
