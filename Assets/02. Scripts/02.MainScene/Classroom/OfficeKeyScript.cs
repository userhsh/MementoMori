using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeKeyScript : MonoBehaviour
{
    private AudioClip unlockSound; // ��� ���� ���带 �����ϴ� ����
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    public float interactionDistance = 1.5f;  // ���� ��ȣ�ۿ��� �ִ� �Ÿ�

    void Start()
    {
        // ����� �ҽ� ������Ʈ�� ������
        audioSource = GetComponent<AudioSource>();
        // ��� ���� ���� ������ �ε�
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }

    private void Update()
    {
        // ���� �������� Raycast ���
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast�� ���� ������Ʈ�� "OFFICEDOOR" �±׸� ���� ���
            if (hit.collider.CompareTag("OFFICEDOOR"))
            {
                // ���� ������Ʈ�� DoorScript�� ������
                DoorScript doorScript = hit.collider.GetComponent<DoorScript>();
                if (doorScript != null && doorScript.isLocked)
                {
                    // ���� ��� ������ ����� ����
                    doorScript.UnlockDoor();
                    // ��� ���� ���带 ��� �� ������Ʈ �ı�
                    audioSource.PlayOneShot(unlockSound);
                    StartCoroutine(DestroyAfterSound());  // ���尡 ����� �� ������Ʈ�� �ı�
                }
            }
        }
    }

    // ���尡 ���� �� ������Ʈ�� �ı��ϴ� �ڷ�ƾ
    private IEnumerator DestroyAfterSound()
    {
        // ���尡 ����Ǵ� ���̸�ŭ ���
        yield return new WaitForSeconds(unlockSound.length);
        // ������Ʈ �ı�
        Destroy(gameObject);
    }
}
