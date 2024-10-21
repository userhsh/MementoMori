using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class DoorScript : MonoBehaviour
{
    private AudioClip openSound;
    private AudioClip closeSound;
    private Collider objectCollider;

    private AudioSource audioSource;  // 오디오 소스
    private XRGrabInteractable grabInteractable;

    public bool isLocked = false;    // 문이 잠겨있는 상태 (기본값: 잠기지 않음)
    bool isOpen = false;
    Animator animator;

    public LockIcon lockIcon;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        openSound = Resources.Load<AudioClip>("DoorSound/doorOpen");
        closeSound = Resources.Load<AudioClip>("DoorSound/doorClose");

        lockIcon?.gameObject.SetActive(false);

        // 물체를 잡을 때 호출되는 이벤트 연결
        grabInteractable.selectEntered.AddListener(OpenCaseDoor);
    }

    // 문 열기/닫기 함수
    public void OpenCaseDoor(SelectEnterEventArgs args)
    {
        if (isLocked)
        {
            lockIcon.gameObject.SetActive(true);
            return;  // 잠긴 상태일 때는 열리지 않음
        }

        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("isOpen", true);
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.55f);
        }
        else
        {
            isOpen = false;
            animator.SetBool("isOpen", false);
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f);
        }
    }

    // 문 잠금을 해제하는 함수 (열쇠 사용 시 호출)
    public void UnlockDoor()
    {
        isLocked = false;  // 잠금 해제
        Debug.Log("문이 잠금 해제되었습니다.");
    }
}
