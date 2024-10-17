using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour, IInteractable
{
    // 문 잠금 여부 판별 변수
    protected bool isLocked;
    // 문 잠금 해제 가능 여부 판별 변수
    protected bool isUnLockable = false;
    // 문 열림 상태 확인 변수
    protected bool isOpen = false;
    // 문 열쇠 이름
    protected string doorKey;
    // 문 애니메이터
    protected Animator doorAnimator = null;
    // 문 애니메이션 파라미터
    protected string doorOpenParameter = "IsOpen";
    // 문 오디오 소스
    protected AudioSource doorAudioSource = null;
    // 문 오디오 클립 배열 0 - 열림, 1 - 닫힘
    protected AudioClip[] doorAudioClips = null;

    public LockIcon lockIcon = null;

    protected AudioClip unlockSound;
    protected AudioSource audioSource;

    Collider keyCollider = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == doorKey)
        {
            keyCollider = collision.collider;
            isUnLockable = true;
        }
    }

    protected void OnCollisionExit(Collision collision) 
    {
        if (collision.collider.gameObject.name == doorKey)
        {
            isUnLockable = false;
            keyCollider = null;
        }
    }

    public void Interact()
    {
        DoorOpen();
    }

    // 문 열고 닫는 메서드
    private void DoorOpen()
    {
        if (isLocked)
        {
            lockIcon?.gameObject.SetActive(false);
            lockIcon?.gameObject.SetActive(true);
        }
        else
        {
            // 문 열림 상태 변경
            isOpen = !isOpen;
            // 문 애니메이션 재생
            doorAnimator.SetBool(doorOpenParameter, isOpen);
            // 열쇠 삭제
            Destroy(keyCollider.gameObject);
            // 문 여닫힘 사운드 재생

        }
    }

    // 문 잠금 해제 메서드
    public void DoorUnlock()
    {
        if (!isUnLockable) return;

        // 문 잠금을 해제 상태로 바꾸기
        isLocked = false;
        // 잠금 해제 소리 재생
        DoorUnLockSound();
    }

    // 문 잠금 해제 소리 재생 메서드
    private void DoorUnLockSound()
    {
        audioSource.PlayOneShot(unlockSound);
    }
}