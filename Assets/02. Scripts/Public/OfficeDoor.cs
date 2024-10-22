using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoor : Door
{
    private void Awake()
    {
        OfficeDoorInit();
    }

    // 사무실 문 init 메서드
    private void OfficeDoorInit()
    {
        doorKey = "OfficeKey";

        isLocked = true;

        doorAnimator = GetComponent<Animator>();

        lockIcon?.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");

        doorOpenSound = Resources.Load<AudioClip>("DoorSound/doorOpen");
        doorCloseSound = Resources.Load<AudioClip>("DoorSound/doorClose");
    }
}