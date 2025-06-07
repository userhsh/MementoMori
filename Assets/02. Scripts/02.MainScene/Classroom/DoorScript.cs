using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorScript : MonoBehaviour
{
    private AudioClip openSound;     // 문이 열릴 때 재생할 오디오 클립
    private AudioClip closeSound;    // 문이 닫힐 때 재생할 오디오 클립
    private AudioSource audioSource; // 문 소리를 재생할 오디오 소스
    private XRGrabInteractable grabInteractable; // XR 상호작용을 위한 XRGrabInteractable 컴포넌트
    private Animator animator;               // 애니메이션을 제어하는 Animator 컴포넌트
    public bool isLocked = false;    // 문이 잠겨있는지 여부 (기본값: 잠기지 않음)
    public bool isOpen = false;      // 문이 열려있는지 여부
    public UITalk uiTalk;            // UI를 통해 상호작용 메시지를 보여줄 UITalk 스크립트

    private void Awake()
    {
        // AudioSource, Animator, XRGrabInteractable 컴포넌트 초기화
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        // 문이 열릴 때와 닫힐 때의 사운드 파일을 Resources 폴더에서 불러오기
        openSound = Resources.Load<AudioClip>("ClassroomSFX/DoorSound/doorOpen");
        closeSound = Resources.Load<AudioClip>("ClassroomSFX/DoorSound/doorClose");

        // 문을 잡을 때 호출되는 이벤트를 OpenCaseDoor 함수와 연결
        grabInteractable.selectEntered.AddListener(OpenCaseDoor);
    }

    // 문을 여는 함수
    public void OpenCaseDoor(SelectEnterEventArgs args)
    {
        if (isLocked) // 문이 잠겨 있는 경우
        {
            //잠김 메시지 출력
            if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
            {
                StartCoroutine(uiTalk.InteractionTalk("Locked.."));
            }
            else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
            {
                StartCoroutine(uiTalk.InteractionTalk("잠겨있다..."));
            }

            return; // 함수 종료
        }

        if (!isOpen) // 문이 닫혀 있으면 열기
        {
            isOpen = true;
            animator.SetBool("IsOpen", true); // 문 열림 애니메이션 활성화
            audioSource.clip = openSound;     // 열림 사운드 설정
            audioSource.PlayDelayed(0.55f);   // 약간의 지연 후 열림 사운드 재생
            Animationing(); // 애니메이션 중 콜라이더 비활성화
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1초 후 콜라이더 활성화
        }
        else // 문이 열려 있으면 닫기
        {
            isOpen = false;
            animator.SetBool("IsOpen", false); // 문 닫힘 애니메이션 활성화
            audioSource.clip = closeSound;     // 닫힘 사운드 설정
            audioSource.PlayDelayed(0.4f);     // 약간의 지연 후 닫힘 사운드 재생
            Animationing(); // 애니메이션 중 콜라이더 비활성화
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1초 후 콜라이더 활성화
        }
    }

    // 문 잠금을 해제하는 함수 (열쇠 사용 시 호출)
    public void UnlockDoor()
    {
        isLocked = false;  // 문 잠금 해제
    }

    // 문 상태를 업데이트하는 함수
    public void UpdateClassroomDoorState()
    {
        animator.SetBool("IsOpen", isOpen); // 애니메이션 상태 업데이트
        if (isOpen)
        {
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.55f); // 열림 상태일 때 사운드 재생
        }
        else
        {
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f); // 닫힘 상태일 때 사운드 재생
        }
    }

    // 애니메이션 중에 문 콜라이더를 비활성화하는 함수
    public void Animationing()
    {
        this.gameObject.GetComponent<Collider>().enabled = false; // 콜라이더 비활성화
    }

    // 애니메이션 종료 후 문 콜라이더를 활성화하는 함수
    public void AnimationEnd()
    {
        this.gameObject.GetComponent<Collider>().enabled = true; // 콜라이더 활성화
    }

    // 일정 시간 후에 문 콜라이더를 다시 활성화하는 코루틴
    private IEnumerator EnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 지연 시간 대기
        AnimationEnd(); // 대기 후 콜라이더 활성화
    }
}
