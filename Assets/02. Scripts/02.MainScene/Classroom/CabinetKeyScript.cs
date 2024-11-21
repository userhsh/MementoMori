using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CabinetKeyScript : MonoBehaviour
{
    private Animator animator;                  // 애니메이터 컴포넌트 (상호작용 중 애니메이션을 제어하기 위해 사용)
    private XRGrabInteractable grabInteractable; // XR 상호작용을 위한 XRGrabInteractable 컴포넌트
    private Rigidbody rb;                       // 물리 상호작용을 위한 리지드바디 컴포넌트
    private Collider objectCollider;            // 충돌을 위한 콜라이더 컴포넌트
    private AudioClip unlockSound;              // 잠금 해제 시 재생할 오디오 클립
    private AudioSource audioSource;            // 오디오 소스 컴포넌트
    public float interactionDistance = 1.5f;    // 상호작용 가능한 최대 거리
    public GameObject cabinetTriggerRayOff;     // 캐비닛 벽뚫 방지 오브젝트

    void Start()
    {
        // Animator, XRGrabInteractable, Collider, AudioSource, Rigidbody 컴포넌트를 초기화
        animator = GetComponentInParent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        // XRGrabInteractable에 물체를 잡을 때와 놓을 때의 이벤트 리스너 추가
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnRelease);

        // 잠금 해제 사운드를 리소스에서 로드
        unlockSound = Resources.Load<AudioClip>("ClassroomSFX/UnlockSound/unlockSound");
    }

    // 캐비닛 문을 잠금 해제하는 함수
    public void UnLockCabinetDoor()
    {
        // 열쇠 방향으로 Raycast 쏘기
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast가 맞은 오브젝트가 "CABINET" 태그를 가진 경우에만 실행
            if (hit.collider.CompareTag("CABINET"))
            {
                DoorScript doorScript = hit.collider.GetComponent<DoorScript>();
                if (doorScript != null && doorScript.isLocked)
                {
                    // 문이 잠겨 있으면 잠금 해제
                    doorScript.UnlockDoor();
                    cabinetTriggerRayOff.SetActive(false);  // 캐비닛 벽뚫 방지 오브젝트 비활성화
                    audioSource.PlayOneShot(unlockSound);   // 잠금 해제 소리 재생
                    StartCoroutine(DestroyAfterSound());   // 소리 재생 후 키 오브젝트 파괴
                }
            }
        }
    }

    // 잠금 해제 사운드가 끝난 후 키 오브젝트를 파괴하는 코루틴
    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(unlockSound.length); // 소리 재생이 끝날 때까지 대기
        Destroy(gameObject); // 키 오브젝트 파괴
    }

    // 물체를 잡았을 때 호출되는 함수
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (animator != null)
        {
            animator.enabled = false;  // Animator 비활성화 (상호작용 중 애니메이션 중단)
        }
    }

    // 물체를 놓았을 때 호출되는 함수
    private void OnRelease(SelectExitEventArgs args)
    {
        // 중력 활성화하여 자연스럽게 떨어지도록 설정
        rb.useGravity = true;
        rb.isKinematic = false;  // 리지드바디를 비활성화하여 물리 상호작용 재활성화
    }
}
