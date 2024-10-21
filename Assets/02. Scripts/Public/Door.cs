using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour, IInteractable
{
    // �� ��� ���� �Ǻ� ����
    protected bool isLocked;
    // �� ��� ���� ���� ���� �Ǻ� ����
    protected bool isUnLockable = false;
    // �� ���� ���� Ȯ�� ����
    protected bool isOpen = false;
    // �� ���� �̸�
    protected string doorKey;
    // �� �ִϸ�����
    protected Animator doorAnimator = null;
    // �� �ִϸ��̼� �Ķ����
    protected string doorOpenParameter = "IsOpen";
    // �� ����� �ҽ�
    protected AudioSource doorAudioSource = null;
    // �� ����� Ŭ�� �迭 0 - ����, 1 - ����
    protected AudioClip[] doorAudioClips = null;

    public LockIcon lockIcon = null;

    protected AudioClip unlockSound;
    protected AudioSource audioSource;

    Collider keyCollider = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == doorKey)
        {
            keyCollider = collision.collider;
            isUnLockable = true;
        }
    }

    protected void OnCollisionExit(Collision collision) 
    {
        if (collision.collider.gameObject.name == doorKey)
        {
            isUnLockable = false;
            keyCollider = null;
        }
    }

    public void Interact()
    {
        DoorOpen();
    }

    // �� ���� �ݴ� �޼���
    private void DoorOpen()
    {
        if (isLocked)
        {
            lockIcon?.gameObject.SetActive(false);
            lockIcon?.gameObject.SetActive(true);
        }
        else
        {
            // ���� ����
            Destroy(keyCollider?.gameObject);
            // �� ���� ���� ����
            isOpen = !isOpen;
            // �� �ִϸ��̼� ���
            doorAnimator.SetBool(doorOpenParameter, isOpen);
            // �� ������ ���� ���
            if (doorAudioClips[0] != null && doorAudioClips[1] != null)
            {
                if (isOpen)
                {
                    audioSource.PlayOneShot(doorAudioClips[0]);
                }
                else
                {
                    audioSource.PlayOneShot(doorAudioClips[1]);
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
        // ��� ���� �Ҹ� ���
        DoorUnLockSound();
    }

    // �� ��� ���� �Ҹ� ��� �޼���
    private void DoorUnLockSound()
    {
        audioSource.PlayOneShot(unlockSound);
    }
}