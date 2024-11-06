using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour, IInteractable
{
    // 문 잠금 여부 판별 변수
    public bool isLocked;
    // 문 잠금 해제 가능 여부 판별 변수
    protected bool isUnLockable = false;
    // 문 열림 상태 확인 변수
    public bool isOpen = false;
    // 문 열쇠 이름
    protected string doorKey;
    // 문 애니메이터
    public Animator doorAnimator = null;
    // 문 애니메이션 파라미터
    protected string doorOpenParameter = "IsOpen";
    // 문 오디오 소스
    protected AudioSource doorAudioSource = null;
    // 문 여는 소리
    protected AudioClip doorOpenSound = null;
    // 문 닫는 소리
    protected AudioClip doorCloseSound = null;
    // 문 잠금 아이콘
    public LockIcon lockIcon = null;
    // 문 잠금 캔버스
    public LockCanvas lockCanvas = null;
    // 문 잠금 해제 소리
    protected AudioClip unlockSound;
    // 문 오디오 소스 컴포넌트
    protected AudioSource audioSource;
    // 열쇠 오브젝트
    public GameObject correctKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == doorKey)
        {
            isUnLockable = true;
        }
    }

    protected void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name == doorKey)
        {
            isUnLockable = false;
        }
    }

    public void Interact()
    {
        DoorOpen(); // 문을 열도록 호출
    }

    // 문 열고 닫는 메서드
    private void DoorOpen()
    {
        if (isLocked)
        {
            lockCanvas?.gameObject.SetActive(false);
            lockCanvas?.gameObject.SetActive(true);
        }
        else
        {
            // 문 열림 상태 변경
            isOpen = !isOpen;
            // 문 애니메이션 재생
            doorAnimator.SetBool(doorOpenParameter, isOpen);
            // 문 여닫힘 사운드 재생
            if (doorOpenSound != null && doorCloseSound != null)
            {
                if (isOpen)
                {
                    audioSource.PlayOneShot(doorOpenSound);
                }
                else
                {
                    audioSource.PlayOneShot(doorCloseSound);
                }
            }

        }
    }

    // 문 잠금 해제 메서드
    public void DoorUnlock()
    {
        if (!isUnLockable) return;

        // 문 잠금을 해제 상태로 바꾸기
        isLocked = false;
        // 잠금 아이콘 끄기
        lockIcon?.gameObject.SetActive(false);
        // 열쇠제거
        if (correctKey != null)
        {
            Destroy(correctKey.gameObject);
        }
        // 잠금 해제 소리 재생
        DoorUnLockSound();
    }

    // 문 잠금 해제 소리 재생 메서드
    private void DoorUnLockSound()
    {
        audioSource.PlayOneShot(unlockSound);
    }
}