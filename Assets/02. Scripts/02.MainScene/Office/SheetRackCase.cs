using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SheetRackCase : SheetRackManager
{

    Vector3 originPosition;

    private void Awake()
    {
        OpenSheetRack();
    }

    private void OnEnable()
    {
        this.transform.position = originPosition;
    }

    private void OpenSheetRack()
    {

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("OfficeSFX/office_locker_O");

        originPosition = transform.position;
    }

    
}
