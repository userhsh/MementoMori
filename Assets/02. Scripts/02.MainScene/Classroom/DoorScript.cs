using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorScript : MonoBehaviour
{
    private AudioClip openSound;     // ���� ���� �� ����� ����� Ŭ��
    private AudioClip closeSound;    // ���� ���� �� ����� ����� Ŭ��
    private AudioSource audioSource; // �� �Ҹ��� ����� ����� �ҽ�
    private XRGrabInteractable grabInteractable; // XR ��ȣ�ۿ��� ���� XRGrabInteractable ������Ʈ
    private Animator animator;               // �ִϸ��̼��� �����ϴ� Animator ������Ʈ
    public bool isLocked = false;    // ���� ����ִ��� ���� (�⺻��: ����� ����)
    public bool isOpen = false;      // ���� �����ִ��� ����
    public UITalk uiTalk;            // UI�� ���� ��ȣ�ۿ� �޽����� ������ UITalk ��ũ��Ʈ

    private void Awake()
    {
        // AudioSource, Animator, XRGrabInteractable ������Ʈ �ʱ�ȭ
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        // ���� ���� ���� ���� ���� ���� ������ Resources �������� �ҷ�����
        openSound = Resources.Load<AudioClip>("ClassroomSFX/DoorSound/doorOpen");
        closeSound = Resources.Load<AudioClip>("ClassroomSFX/DoorSound/doorClose");

        // ���� ���� �� ȣ��Ǵ� �̺�Ʈ�� OpenCaseDoor �Լ��� ����
        grabInteractable.selectEntered.AddListener(OpenCaseDoor);
    }

    // ���� ���� �Լ�
    public void OpenCaseDoor(SelectEnterEventArgs args)
    {
        if (isLocked) // ���� ��� �ִ� ���
        {
            //��� �޽��� ���
            if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
            {
                StartCoroutine(uiTalk.InteractionTalk("Locked.."));
            }
            else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
            {
                StartCoroutine(uiTalk.InteractionTalk("����ִ�..."));
            }

            return; // �Լ� ����
        }

        if (!isOpen) // ���� ���� ������ ����
        {
            isOpen = true;
            animator.SetBool("IsOpen", true); // �� ���� �ִϸ��̼� Ȱ��ȭ
            audioSource.clip = openSound;     // ���� ���� ����
            audioSource.PlayDelayed(0.55f);   // �ణ�� ���� �� ���� ���� ���
            Animationing(); // �ִϸ��̼� �� �ݶ��̴� ��Ȱ��ȭ
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1�� �� �ݶ��̴� Ȱ��ȭ
        }
        else // ���� ���� ������ �ݱ�
        {
            isOpen = false;
            animator.SetBool("IsOpen", false); // �� ���� �ִϸ��̼� Ȱ��ȭ
            audioSource.clip = closeSound;     // ���� ���� ����
            audioSource.PlayDelayed(0.4f);     // �ణ�� ���� �� ���� ���� ���
            Animationing(); // �ִϸ��̼� �� �ݶ��̴� ��Ȱ��ȭ
            StartCoroutine(EnableColliderAfterDelay(1f)); // 1�� �� �ݶ��̴� Ȱ��ȭ
        }
    }

    // �� ����� �����ϴ� �Լ� (���� ��� �� ȣ��)
    public void UnlockDoor()
    {
        isLocked = false;  // �� ��� ����
    }

    // �� ���¸� ������Ʈ�ϴ� �Լ�
    public void UpdateClassroomDoorState()
    {
        animator.SetBool("IsOpen", isOpen); // �ִϸ��̼� ���� ������Ʈ
        if (isOpen)
        {
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.55f); // ���� ������ �� ���� ���
        }
        else
        {
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f); // ���� ������ �� ���� ���
        }
    }

    // �ִϸ��̼� �߿� �� �ݶ��̴��� ��Ȱ��ȭ�ϴ� �Լ�
    public void Animationing()
    {
        this.gameObject.GetComponent<Collider>().enabled = false; // �ݶ��̴� ��Ȱ��ȭ
    }

    // �ִϸ��̼� ���� �� �� �ݶ��̴��� Ȱ��ȭ�ϴ� �Լ�
    public void AnimationEnd()
    {
        this.gameObject.GetComponent<Collider>().enabled = true; // �ݶ��̴� Ȱ��ȭ
    }

    // ���� �ð� �Ŀ� �� �ݶ��̴��� �ٽ� Ȱ��ȭ�ϴ� �ڷ�ƾ
    private IEnumerator EnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���� �ð� ���
        AnimationEnd(); // ��� �� �ݶ��̴� Ȱ��ȭ
    }
}
