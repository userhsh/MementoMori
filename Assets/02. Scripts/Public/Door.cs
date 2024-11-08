using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour, IInteractable
{
    // �� ��� ���� �Ǻ� ����
    public bool isLocked;
    // �� ��� ���� ���� ���� �Ǻ� ����
    protected bool isUnLockable = false;
    // �� ���� ���� Ȯ�� ����
    public bool isOpen = false;
    // �� ���� �̸�
    protected string doorKey;
    // �� �ִϸ�����
    public Animator doorAnimator = null;
    // �� �ִϸ��̼� �Ķ����
    protected string doorOpenParameter = "IsOpen";
    // �� ����� �ҽ�
    protected AudioSource doorAudioSource = null;
    // �� ���� �Ҹ�
    protected AudioClip doorOpenSound = null;
    // �� �ݴ� �Ҹ�
    protected AudioClip doorCloseSound = null;
    // �� ��� ������
    public LockIcon lockIcon = null;
    // �� ��� ĵ����
    public LockCanvas lockCanvas = null;
    // �� ��� ���� �Ҹ�
    protected AudioClip unlockSound;
    // �� ����� �ҽ� ������Ʈ
    protected AudioSource audioSource;
    // ���� ������Ʈ
    public GameObject correctKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == doorKey)
        {
            isUnLockable = true;
        }
    }

    protected void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name == doorKey)
        {
            isUnLockable = false;
        }
    }

    public void Interact()
    {
        DoorOpen(); // ���� ������ ȣ��
    }

    // �� ���� �ݴ� �޼���
    private void DoorOpen()
    {
        if (isLocked)
        {
            lockCanvas?.gameObject.SetActive(false);
            lockCanvas?.gameObject.SetActive(true);
        }
        else
        {
            // �� ���� ���� ����
            isOpen = !isOpen;
            // �� �ִϸ��̼� ���
            doorAnimator.SetBool(doorOpenParameter, isOpen);
            // �� ������ ���� ���
            if (doorOpenSound != null && doorCloseSound != null)
            {
                if (isOpen)
                {
                    audioSource.PlayOneShot(doorOpenSound);
                }
                else
                {
                    audioSource.PlayOneShot(doorCloseSound);
                }
            }

        }
    }

    // �� ��� ���� �޼���
    public void DoorUnlock()
    {
        if (!isUnLockable) return;

        // �� ����� ���� ���·� �ٲٱ�
        isLocked = false;
        // ��� ������ ����
        lockIcon?.gameObject.SetActive(false);
        // ��������
        if (correctKey != null)
        {
            Destroy(correctKey.gameObject);
        }
        // ��� ���� �Ҹ� ���
        DoorUnLockSound();
    }

    // �� ��� ���� �Ҹ� ��� �޼���
    private void DoorUnLockSound()
    {
        audioSource.PlayOneShot(unlockSound);
    }
}