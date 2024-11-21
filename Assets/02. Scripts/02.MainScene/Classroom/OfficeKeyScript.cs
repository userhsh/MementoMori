using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeKeyScript : MonoBehaviour
{
    private AudioClip unlockSound; // 잠금 해제 사운드를 저장하는 변수
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    public float interactionDistance = 1.5f;  // 문과 상호작용할 최대 거리

    void Start()
    {
        // 오디오 소스 컴포넌트를 가져옴
        audioSource = GetComponent<AudioSource>();
        // 잠금 해제 사운드 파일을 로드
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }

    private void Update()
    {
        // 열쇠 앞쪽으로 Raycast 쏘기
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast가 맞은 오브젝트가 "OFFICEDOOR" 태그를 가진 경우
            if (hit.collider.CompareTag("OFFICEDOOR"))
            {
                // 맞은 오브젝트의 DoorScript를 가져옴
                DoorScript doorScript = hit.collider.GetComponent<DoorScript>();
                if (doorScript != null && doorScript.isLocked)
                {
                    // 문이 잠겨 있으면 잠금을 해제
                    doorScript.UnlockDoor();
                    // 잠금 해제 사운드를 재생 후 오브젝트 파괴
                    audioSource.PlayOneShot(unlockSound);
                    StartCoroutine(DestroyAfterSound());  // 사운드가 재생된 후 오브젝트를 파괴
                }
            }
        }
    }

    // 사운드가 끝난 후 오브젝트를 파괴하는 코루틴
    private IEnumerator DestroyAfterSound()
    {
        // 사운드가 재생되는 길이만큼 대기
        yield return new WaitForSeconds(unlockSound.length);
        // 오브젝트 파괴
        Destroy(gameObject);
    }
}
