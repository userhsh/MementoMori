using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoor : Door
{
    private void Awake()
    {
        OfficeDoorInit();
    }

    // �繫�� �� init �޼���
    private void OfficeDoorInit()
    {
        doorKey = "OfficeKey";

        isLocked = true;

        doorAnimator = GetComponent<Animator>();

        lockIcon?.gameObject.SetActive(true);
        lockCanvas?.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("HallwaySFX/UnlockSound/unlockSound");

        doorOpenSound = Resources.Load<AudioClip>("HallwaySFX/DoorSound/doorOpen");
        doorCloseSound = Resources.Load<AudioClip>("HallwaySFX/DoorSound/doorClose");
    }
}