using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueDoor : Door
{
    public MorgueDoor anotherDoor = null;

    private void Awake()
    {
        MorgueDoorInit();
    }

    private void Update()
    {
        // �ٸ� ���� ��� ���� ������ ��� ���� �� ����� ����
        if (anotherDoor != null && !anotherDoor.isLocked)
        {
            this.isLocked = false;
        }
        // ���� ���� ��� ���� ������ ��� �ٸ� ���� ��� ����
        else if (this.isLocked == false && anotherDoor != null)
        {
            anotherDoor.isLocked = false;
        }
    }

    // ��ü ��ġ�� �� init �޼���
    private void MorgueDoorInit()
    {
        doorKey = "MorgueKey";

        isLocked = true;

        doorAnimator = GetComponent<Animator>();

        lockIcon?.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("HallwaySFX/UnlockSound/unlockSound");

        doorOpenSound = Resources.Load<AudioClip>("HallwaySFX/DoorSound/doorOpen");
        doorCloseSound = Resources.Load<AudioClip>("HallwaySFX/DoorSound/doorClose");
    }

    public void UpdateMorgueDoorState()
    {
        // ��� ���°� ������ ��� ��� ������ �����
        if (!isLocked)
        {
            lockIcon?.gameObject.SetActive(false);
        }

        // ����/���� ���¿� ���� �ִϸ��̼� ����
        doorAnimator.SetBool("IsOpen", isOpen);
    }
}