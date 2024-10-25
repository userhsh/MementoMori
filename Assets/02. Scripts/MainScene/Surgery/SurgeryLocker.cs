using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavKeypad;

public class SurgeryLocker : MonoBehaviour
{
    Keypad surgeryKeypad = null;
    Animator openAnimator = null;

    private void Awake()
    {
        SurgeryLockerInit();
    }

    private void Update()
    {
        LockerOpen();
    }

    private void SurgeryLockerInit()
    {
        surgeryKeypad = GetComponentInChildren<Keypad>();
        openAnimator = GetComponentInChildren<Animator>();
    }

    private void LockerOpen()
    {
        if (surgeryKeypad.AccessWasGranted)
        {
            openAnimator.SetTrigger("IsOpen");
        }
    }
}