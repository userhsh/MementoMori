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
    bool isOpen = false;
    Animator animator;

    public LockIcon lockIcon;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        openSound = Resources.Load<AudioClip>("DoorSound/doorOpen");
        closeSound = Resources.Load<AudioClip>("DoorSound/doorClose");

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
            animator.SetBool("isOpen", true);
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.55f);
        }
        else
        {
            isOpen = false;
            animator.SetBool("isOpen", false);
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f);
        }
    }

    // �� ����� �����ϴ� �Լ� (���� ��� �� ȣ��)
    public void UnlockDoor()
    {
        isLocked = false;  // ��� ����
        Debug.Log("���� ��� �����Ǿ����ϴ�.");
    }
}
