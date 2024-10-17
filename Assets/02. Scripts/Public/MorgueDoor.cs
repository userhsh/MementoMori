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
        if (anotherDoor.isLocked == false)
        {
            this.isLocked = false;
        }
        else if (this.isLocked == false)
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
    }
}