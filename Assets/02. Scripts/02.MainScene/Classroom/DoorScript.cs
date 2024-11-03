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

    private AudioSource audioSource;  // ����� �ҽ�
    private XRGrabInteractable grabInteractable;

    public bool isLocked = false;    // ���� ����ִ� ���� (�⺻��: ����� ����)
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

        // ��ü�� ���� �� ȣ��Ǵ� �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(OpenCaseDoor);
    }

    // �� ����/�ݱ� �Լ�
    public void OpenCaseDoor(SelectEnterEventArgs args)
    {
        if (isLocked)
        {
            lockIcon.gameObject.SetActive(true);
            return;  // ��� ������ ���� ������ ����
        }

        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("IsOpen", true);
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.55f);
            Animationing(); // �ִϸ��̼� ���� �� �ݶ��̴� ��Ȱ��ȭ
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1�� �� �ݶ��̴� Ȱ��ȭ
        }
        else
        {
            isOpen = false;
            animator.SetBool("IsOpen", false);
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f);
            Animationing(); // �ִϸ��̼� ���� �� �ݶ��̴� ��Ȱ��ȭ
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1�� �� �ݶ��̴� Ȱ��ȭ
        }
    }

    // �� ����� �����ϴ� �Լ� (���� ��� �� ȣ��)
    public void UnlockDoor()
    {
        isLocked = false;  // ��� ����
        Debug.Log("���� ��� �����Ǿ����ϴ�.");
    }

    public void UpdateClassroomDoorState()
    {
        // ��� ���°� ������ ��� ��� ������ �����
        if (!isLocked)
        {
            lockIcon?.gameObject.SetActive(false);
        }

        // ����/���� ���¿� ���� �ִϸ��̼� ����
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

    // �ݶ��̴��� ���� �ð� �Ŀ� Ȱ��ȭ�ϴ� �ڷ�ƾ
    private IEnumerator EnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AnimationEnd(); // ���� �ð� �� �ݶ��̴� Ȱ��ȭ
    }
}
