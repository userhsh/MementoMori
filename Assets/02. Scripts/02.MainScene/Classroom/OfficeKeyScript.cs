using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeKeyScript : MonoBehaviour
{
    private AudioClip unlockSound;
    private AudioSource audioSource;

    public float interactionDistance = 1.5f;  // ������ ��ȣ�ۿ� �ִ� �Ÿ�

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }

    private void Update()
    {
        // ���� �������� Raycast ���
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast�� ���� ������Ʈ�� ���� ���
            if (hit.collider.CompareTag("OFFICEDOOR"))
            {
                DoorScript doorScript = hit.collider.GetComponent<DoorScript>();
                if (doorScript != null && doorScript.isLocked)
                {
                    // ���� ��������� ��� ����
                    doorScript.UnlockDoor();
                    Debug.Log("Raycast�� ���� ����� ���� �������ϴ�.");
                    // Unlock ���� ��� �� ������Ʈ �ı�
                    audioSource.PlayOneShot(unlockSound);
                    StartCoroutine(DestroyAfterSound());  // ���尡 ����� �� �ı�
                }
            }
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        // ���尡 ���� ������ ���
        yield return new WaitForSeconds(unlockSound.length);
        Destroy(gameObject);
    }
}
