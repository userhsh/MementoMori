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

    // ������ �� init �޼���
    private void SurgeryDoorInit()
    {
        doorKey = "SurgeryKey";

        isLocked = true;

        doorAnimator = GetComponent<Animator>();

        lockIcon?.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");

        doorAudioClips[0] = Resources.Load<AudioClip>("DoorSound/doorOpen");
        doorAudioClips[1] = Resources.Load<AudioClip>("DoorSound/doorClose");
    }
}