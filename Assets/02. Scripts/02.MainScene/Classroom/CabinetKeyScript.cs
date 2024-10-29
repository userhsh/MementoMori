using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CabinetKeyScript : MonoBehaviour
{
    private Animator animator;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private Collider objectCollider;
    private AudioClip unlockSound;
    private AudioSource audioSource;

    public float interactionDistance = 1.5f;  // 문과의 상호작용 최대 거리

    void Start()
    {
        // Animator 컴포넌트와 XRGrabInteractable 컴포넌트를 가져옴
        animator = GetComponentInParent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        // 물체를 잡을 때 호출되는 이벤트 연결
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnRelease);

        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }

    private void Update()
    {
        // 열쇠 앞쪽으로 Raycast 쏘기
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast가 맞은 오브젝트가 문인 경우
            if (hit.collider.CompareTag("CABINET"))
            {
                DoorScript doorScript = hit.collider.GetComponent<DoorScript>();
                if (doorScript != null && doorScript.isLocked)
                {
                    // 문이 잠겨있으면 잠금 해제
                    doorScript.UnlockDoor();
                    Debug.Log("Raycast를 통해 열쇠로 문을 열었습니다.");
                    // Unlock 사운드 재생 후 오브젝트 파괴
                    audioSource.PlayOneShot(unlockSound);
                    StartCoroutine(DestroyAfterSound());  // 사운드가 재생된 후 파괴
                }
            }
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        // 사운드가 끝날 때까지 대기
        yield return new WaitForSeconds(unlockSound.length);
        Destroy(gameObject);
    }

    // 물체가 잡혔을 때 호출되는 함수
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (animator != null)
        {
            animator.enabled = false;  // Animator 비활성화
            
        }
    }

    // 오브젝트를 놓았을 때 호출되는 함수
    private void OnRelease(SelectExitEventArgs args)
    {
        // 중력 활성화
        rb.useGravity = true;
        rb.isKinematic = false;  // 놓았을 때 다시 물리 상호작용 활성화
    }
}
