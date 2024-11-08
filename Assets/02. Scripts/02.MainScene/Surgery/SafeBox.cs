using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : MonoBehaviour, IInteractable
{
    SafeBoxDoor safeBoxDoor = null;
    SafeBoxCardMechine safeBoxCardMechine = null;

    // ���� ��� ���θ� Ȯ���� ���� ����
    bool isLocked = true;
    // ���� �� �� �ִ� �������� Ȯ���� ���� ����(���� ��������, ���� �������� ����)
    bool isOpenable = true;

    bool isTrigger = false;

    // �ִϸ����� �Ķ���� �̸��� ���� ���� ����
    string parameterName;

    Collider doctorCard = null;

    private AudioSource audioSource;
    private AudioClip SafeUnlock;
    private AudioClip SafeOpen;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SafeBoxInit();
    }

    private void Start()
    {
        SafeUnlock = Resources.Load<AudioClip>("SurgerySFX/SafeUnlock");
        SafeOpen = Resources.Load<AudioClip>("SurgerySFX/SafeOpen");
    }

    // �ݰ� Init �޼���
    public void SafeBoxInit()
    {
        safeBoxDoor = GetComponentInChildren<SafeBoxDoor>();
        safeBoxCardMechine = GetComponentInChildren<SafeBoxCardMechine>();
        safeBoxDoor.SafeDoorInit();
        safeBoxCardMechine.CardMechineInit();
    }

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        doctorCard = other;
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }

    public void Interact()
    {
        if (!isTrigger) return;

        // �ǻ� ī�尡 ���� �� ����� ����
        isLocked = false;

        safeBoxCardMechine.ChangeColor();

        audioSource.PlayOneShot(SafeUnlock);

        Invoke("DoorOpen", 1f);

        doctorCard?.gameObject.SetActive(false);
    }

    private void DoorOpen()
    {
        // ����� �ִ� ���°� �ƴ϶��
        if (!isLocked)
        {
            // isOpenable�� ���¿� ���� �Ķ���� �̸� ��������
            parameterName = (isOpenable) ? "IsOpen" : "IsClose";
            // ������ �Ķ���ͷ� �ִϸ��̼� ���
            safeBoxDoor.SafeDoorAnimator.SetTrigger(parameterName);
            // isOpenable ���� �ٲ��ֱ�
            isOpenable = !isOpenable;
            audioSource.PlayOneShot(SafeOpen);
        }
    }
}