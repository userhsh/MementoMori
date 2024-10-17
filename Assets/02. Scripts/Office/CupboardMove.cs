using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardMove : MonoBehaviour, IInteractable
{

    Animator openAnimator = null;

    bool isDoorOpen = false;

    private void Awake()
    {
        openAnimator = GetComponent<Animator>();
        openAnimator.SetBool("isDoorOpen", false);
        isDoorOpen = false;
    }

    public void Interact()
    {
        if (isDoorOpen == false)
        {
            openAnimator.SetBool("isDoorOpen", true);
            isDoorOpen = true;
        }
        else
        {
            openAnimator.SetBool("isDoorOpen", false);
            isDoorOpen = false;
        }    
    }
}
