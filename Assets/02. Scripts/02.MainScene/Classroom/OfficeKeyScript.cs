using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeKeyScript : MonoBehaviour
{
    private AudioClip unlockSound;
    private AudioSource audioSource;

    public float interactionDistance = 1.5f;  // 문과의 상호작용 최대 거리

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }

    private void Update()
    {
        // 열쇠 앞쪽으로 Raycast 쏘기
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast가 맞은 오브젝트가 문인 경우
            if (hit.collider.CompareTag("OFFICEDOOR"))
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
}
