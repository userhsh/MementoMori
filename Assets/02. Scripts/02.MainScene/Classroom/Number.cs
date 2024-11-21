using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Number : MonoBehaviour
{
    // 특정 숫자를 활성화/비활성화하는 데 사용할 GameObject 참조
    public GameObject Number9, Number1;
    private XRGrabInteractable grabinteractable;  // XR 상호작용을 위한 XRGrabInteractable 컴포넌트
    private Vector3 originalParentPosition;      // 부모 객체의 원래 위치
    private Quaternion originalParentRotation;   // 부모 객체의 원래 회전값
    private Vector3 originalLocalChildPositions; // 자식 객체의 원래 로컬 위치
    private Quaternion originalLocalChildRotations; // 자식 객체의 원래 로컬 회전값
    private Groove1 groove1;  // Groove1 스크립트 참조
    private Groove2 groove2;  // Groove2 스크립트 참조

    private void Awake()
    {
        // XRGrabInteractable, Groove1, Groove2 컴포넌트를 초기화
        grabinteractable = GetComponent<XRGrabInteractable>();
        groove1 = FindObjectOfType<Groove1>();
        groove2 = FindObjectOfType<Groove2>();
    }

    private void Start()
    {
        // XR 상호작용 이벤트 설정
        grabinteractable.selectExited.AddListener(OnRelease);  // 놓을 때 호출
        grabinteractable.activated.AddListener(TriggerOn);    // 트리거 버튼을 누를 때 호출

        // 부모 객체의 원래 위치와 회전값을 저장 (월드 좌표)
        originalParentPosition = transform.position;
        originalParentRotation = transform.rotation;

        // 자식 객체의 원래 로컬 위치와 회전값을 저장
        originalLocalChildPositions = transform.localPosition;
        originalLocalChildRotations = transform.localRotation;
    }

    // 객체가 놓였을 때 호출되는 함수
    private void OnRelease(SelectExitEventArgs args)
    {
        // 부모 객체의 위치와 회전값을 원래대로 복구 (월드 좌표)
        transform.position = originalParentPosition;
        transform.rotation = originalParentRotation;

        // 자식 객체의 로컬 위치와 회전값을 원래대로 복구
        transform.localPosition = originalLocalChildPositions;
        transform.localRotation = originalLocalChildRotations;
    }

    // 트리거 버튼을 눌렀을 때 호출되는 함수
    private void TriggerOn(ActivateEventArgs args)
    {
        // Groove1에서 정답을 맞췄을 경우
        if (groove1.CorrectA)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[1]); // 정답 소리 재생

            groove1.Numbers[8].SetActive(false); // 9번 숫자 비활성화
            Number9.SetActive(true);             // Number9 활성화
            groove1.Numbers[8].GetComponent<Collider>().enabled = false; // 충돌 비활성화

            groove1.CorrectA = false; // 정답 상태를 초기화

            return; // 함수 종료
        }

        // Groove2에서 정답을 맞췄을 경우
        if (groove2.CorrectB)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[1]); // 정답 소리 재생

            groove1.Numbers[0].SetActive(false); // 1번 숫자 비활성화
            Number1.SetActive(true);             // Number1 활성화
            groove1.Numbers[0].GetComponent<Collider>().enabled = false; // 충돌 비활성화

            groove2.CorrectB = false; // 정답 상태 초기화

            return; // 함수 종료
        }

        // Groove1 또는 Groove2에서 오답일 경우
        if (groove1.isWrong == true && !groove1.audioSource.isPlaying)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[0]); // 오답 소리 재생
        }

        if (groove2.IsWrong == true && !groove1.audioSource.isPlaying)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[0]); // 오답 소리 재생
        }
    }
}
