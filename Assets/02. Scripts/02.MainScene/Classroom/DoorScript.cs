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
    public bool isOpen = false;
    Animator animator;

    public LockIcon lockIcon;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        openSound = Resources.Load<AudioClip>("ClassroomSFX/DoorSound/doorOpen");
        closeSound = Resources.Load<AudioClip>("ClassroomSFX/DoorSound/doorClose");

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
            animator.SetBool("IsOpen", true);
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.55f);
            Animationing(); // 애니메이션 시작 시 콜라이더 비활성화
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1초 후 콜라이더 활성화
        }
        else
        {
            isOpen = false;
            animator.SetBool("IsOpen", false);
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f);
            Animationing(); // 애니메이션 시작 시 콜라이더 비활성화
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1초 후 콜라이더 활성화
        }
    }

    // 문 잠금을 해제하는 함수 (열쇠 사용 시 호출)
    public void UnlockDoor()
    {
        isLocked = false;  // 잠금 해제
        Debug.Log("문이 잠금 해제되었습니다.");
    }

    public void UpdateClassroomDoorState()
    {
        // 잠금 상태가 해제된 경우 잠금 아이콘 숨기기
        if (!isLocked)
        {
            lockIcon?.gameObject.SetActive(false);
        }

        // 열림/닫힘 상태에 따라 애니메이션 설정
        animator.SetBool("IsOpen", isOpen);
        if (isOpen)
        {
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.55f);
        }
        else
        {
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f);
        }
    }

    public void Animationing()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
    }
    public void AnimationEnd()
    {
        this.gameObject.GetComponent<Collider>().enabled = true;
    }

    // 콜라이더를 일정 시간 후에 활성화하는 코루틴
    private IEnumerator EnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AnimationEnd(); // 일정 시간 후 콜라이더 활성화
    }
}
