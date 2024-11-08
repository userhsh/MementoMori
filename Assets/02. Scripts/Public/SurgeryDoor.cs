using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryDoor : Door
{
    public SurgeryDoor anotherDoor = null;

    private void Awake()
    {
        SurgeryDoorInit();
    }

    private void Update()
    {
        if (anotherDoor.isLocked == false) 
        {
            this.isLocked = false;
        }
        else if (this.isLocked == false)
        {
            anotherDoor.isLocked = false;
        }
    }

    // 수술실 문 init 메서드
    private void SurgeryDoorInit()
    {
        doorKey = "SurgeryKey";

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