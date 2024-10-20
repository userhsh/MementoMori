using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardMove : MonoBehaviour, IInteractable
{

    Animator openAnimator = null;
    AudioSource officeCupSound = null;
    AudioClip officeCupOpenClip = null;
    AudioClip officeCupCloseClip = null;

    bool isDoorOpen = false;

    private void Awake()
    {
        officeCupSound = GetComponent<AudioSource>();
        officeCupOpenClip = Resources.Load<AudioClip>("OfficeSFX/cupboard1_O");
        officeCupCloseClip = Resources.Load<AudioClip>("OfficeSFX/cupboard1_C");

        openAnimator = GetComponent<Animator>();
        openAnimator.SetBool("isDoorOpen", false);
        isDoorOpen = false;
    }

    public void Interact()
    {
        if (isDoorOpen == false)
        {
            openAnimator.SetBool("isDoorOpen", true);
            officeCupSound.PlayOneShot(officeCupOpenClip);
            isDoorOpen = true;
        }
        else
        {
            openAnimator.SetBool("isDoorOpen", false);
            officeCupSound.PlayOneShot(officeCupCloseClip);
            isDoorOpen = false;
        }    
    }
}
