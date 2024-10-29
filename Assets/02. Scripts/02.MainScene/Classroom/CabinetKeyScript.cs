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

    public float interactionDistance = 1.5f;  // ������ ��ȣ�ۿ� �ִ� �Ÿ�

    void Start()
    {
        // Animator ������Ʈ�� XRGrabInteractable ������Ʈ�� ������
        animator = GetComponentInParent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        // ��ü�� ���� �� ȣ��Ǵ� �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnRelease);

        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }

    private void Update()
    {
        // ���� �������� Raycast ���
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast�� ���� ������Ʈ�� ���� ���
            if (hit.collider.CompareTag("CABINET"))
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

    // ��ü�� ������ �� ȣ��Ǵ� �Լ�
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (animator != null)
        {
            animator.enabled = false;  // Animator ��Ȱ��ȭ
            
        }
    }

    // ������Ʈ�� ������ �� ȣ��Ǵ� �Լ�
    private void OnRelease(SelectExitEventArgs args)
    {
        // �߷� Ȱ��ȭ
        rb.useGravity = true;
        rb.isKinematic = false;  // ������ �� �ٽ� ���� ��ȣ�ۿ� Ȱ��ȭ
    }
}
