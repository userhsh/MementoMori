using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomDoor : Door
{
    private void Awake()
    {
        ClassroomDoorInit();
    }

    // 학교 문 init 메서드
    private void ClassroomDoorInit()
    {
        doorKey = "ClassroomKey";

        isLocked = false;

        doorAnimator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }
}