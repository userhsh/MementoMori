using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomDoor : Door
{
    private void Awake()
    {
        ClassroomDoorInit();
    }

    // �б� �� init �޼���
    private void ClassroomDoorInit()
    {
        doorKey = "ClassroomKey";

        isLocked = false;

        doorAnimator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }
}