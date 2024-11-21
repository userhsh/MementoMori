using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CabinetKeyScript : MonoBehaviour
{
    private Animator animator;                  // �ִϸ����� ������Ʈ (��ȣ�ۿ� �� �ִϸ��̼��� �����ϱ� ���� ���)
    private XRGrabInteractable grabInteractable; // XR ��ȣ�ۿ��� ���� XRGrabInteractable ������Ʈ
    private Rigidbody rb;                       // ���� ��ȣ�ۿ��� ���� ������ٵ� ������Ʈ
    private Collider objectCollider;            // �浹�� ���� �ݶ��̴� ������Ʈ
    private AudioClip unlockSound;              // ��� ���� �� ����� ����� Ŭ��
    private AudioSource audioSource;            // ����� �ҽ� ������Ʈ
    public float interactionDistance = 1.5f;    // ��ȣ�ۿ� ������ �ִ� �Ÿ�
    public GameObject cabinetTriggerRayOff;     // ĳ��� ���� ���� ������Ʈ

    void Start()
    {
        // Animator, XRGrabInteractable, Collider, AudioSource, Rigidbody ������Ʈ�� �ʱ�ȭ
        animator = GetComponentInParent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        // XRGrabInteractable�� ��ü�� ���� ���� ���� ���� �̺�Ʈ ������ �߰�
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnRelease);

        // ��� ���� ���带 ���ҽ����� �ε�
        unlockSound = Resources.Load<AudioClip>("ClassroomSFX/UnlockSound/unlockSound");
    }

    // ĳ��� ���� ��� �����ϴ� �Լ�
    public void UnLockCabinetDoor()
    {
        // ���� �������� Raycast ���
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            // Raycast�� ���� ������Ʈ�� "CABINET" �±׸� ���� ��쿡�� ����
            if (hit.collider.CompareTag("CABINET"))
            {
                DoorScript doorScript = hit.collider.GetComponent<DoorScript>();
                if (doorScript != null && doorScript.isLocked)
                {
                    // ���� ��� ������ ��� ����
                    doorScript.UnlockDoor();
                    cabinetTriggerRayOff.SetActive(false);  // ĳ��� ���� ���� ������Ʈ ��Ȱ��ȭ
                    audioSource.PlayOneShot(unlockSound);   // ��� ���� �Ҹ� ���
                    StartCoroutine(DestroyAfterSound());   // �Ҹ� ��� �� Ű ������Ʈ �ı�
                }
            }
        }
    }

    // ��� ���� ���尡 ���� �� Ű ������Ʈ�� �ı��ϴ� �ڷ�ƾ
    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(unlockSound.length); // �Ҹ� ����� ���� ������ ���
        Destroy(gameObject); // Ű ������Ʈ �ı�
    }

    // ��ü�� ����� �� ȣ��Ǵ� �Լ�
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (animator != null)
        {
            animator.enabled = false;  // Animator ��Ȱ��ȭ (��ȣ�ۿ� �� �ִϸ��̼� �ߴ�)
        }
    }

    // ��ü�� ������ �� ȣ��Ǵ� �Լ�
    private void OnRelease(SelectExitEventArgs args)
    {
        // �߷� Ȱ��ȭ�Ͽ� �ڿ������� ���������� ����
        rb.useGravity = true;
        rb.isKinematic = false;  // ������ٵ� ��Ȱ��ȭ�Ͽ� ���� ��ȣ�ۿ� ��Ȱ��ȭ
    }
}
