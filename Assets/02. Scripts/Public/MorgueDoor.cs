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
        // 다른 문이 잠금 해제 상태인 경우 현재 문 잠금을 해제
        if (anotherDoor != null && !anotherDoor.isLocked)
        {
            this.isLocked = false;
        }
        // 현재 문이 잠금 해제 상태일 경우 다른 문도 잠금 해제
        else if (this.isLocked == false && anotherDoor != null)
        {
            anotherDoor.isLocked = false;
        }
    }

    // 시체 안치실 문 init 메서드
    private void MorgueDoorInit()
    {
        doorKey = "MorgueKey";

        isLocked = true;

        doorAnimator = GetComponent<Animator>();

        lockIcon?.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");

        doorOpenSound = Resources.Load<AudioClip>("DoorSound/doorOpen");
        doorCloseSound = Resources.Load<AudioClip>("DoorSound/doorClose");
    }
}