using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetRackCase : MonoBehaviour
{
    Animator animator = null;
    AudioSource audioSource = null;
    AudioClip clip = null;  

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("OfficeSFX/office_locker_O");
    }

    public void Interact()
    {
        animator.SetTrigger("CabinetClick");
        audioSource.PlayOneShot(clip);
        Destroy(gameObject, 1f);
    }

}
