using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : MonoBehaviour, IInteractable
{
    SafeBoxDoor safeBoxDoor = null;
    SafeBoxCardMechine safeBoxCardMechine = null;

    // 문의 잠금 여부를 확인할 변수 선언
    bool isLocked = true;
    // 문을 열 수 있는 상태인지 확인할 변수 선언(열린 상태인지, 닫힌 상태인지 구분)
    bool isOpenable = true;

    bool isTrigger = false;

    // 애니메이터 파라미터 이름을 받을 변수 선언
    string parameterName;

    Collider doctorCard = null;

    private AudioSource audioSource;
    private AudioClip SafeUnlock;
    private AudioClip SafeOpen;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SafeBoxInit();
    }

    private void Start()
    {
        SafeUnlock = Resources.Load<AudioClip>("SurgerySFX/SafeUnlock");
        SafeOpen = Resources.Load<AudioClip>("SurgerySFX/SafeOpen");
    }

    // 금고 Init 메서드
    public void SafeBoxInit()
    {
        safeBoxDoor = GetComponentInChildren<SafeBoxDoor>();
        safeBoxCardMechine = GetComponentInChildren<SafeBoxCardMechine>();
        safeBoxDoor.SafeDoorInit();
        safeBoxCardMechine.CardMechineInit();
    }

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        doctorCard = other;
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }

    public void Interact()
    {
        if (!isTrigger) return;

        // 의사 카드가 있을 때 잠금을 해제
        isLocked = false;

        safeBoxCardMechine.ChangeColor();

        audioSource.PlayOneShot(SafeUnlock);

        Invoke("DoorOpen", 1f);

        doctorCard?.gameObject.SetActive(false);
    }

    private void DoorOpen()
    {
        // 잠겨져 있는 상태가 아니라면
        if (!isLocked)
        {
            // isOpenable의 상태에 따라 파라미터 이름 가져오기
            parameterName = (isOpenable) ? "IsOpen" : "IsClose";
            // 가져온 파라미터로 애니메이션 재생
            safeBoxDoor.SafeDoorAnimator.SetTrigger(parameterName);
            // isOpenable 상태 바꿔주기
            isOpenable = !isOpenable;
            audioSource.PlayOneShot(SafeOpen);
        }
    }
}