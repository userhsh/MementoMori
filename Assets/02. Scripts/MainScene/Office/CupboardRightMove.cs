using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardRightMove : MonoBehaviour, IInteractable
{

    Animator cupboardRightAnim = null;
    
    bool isDoorOpen = false;


    private void Awake()
    {
        cupboardRightAnim = GetComponent<Animator>();
    }

    public void Interact()
    {
        if(isDoorOpen == false) 
        { 
            cupboardRightAnim.SetBool("isDoorOpen",true);
            isDoorOpen = true;
        }
        else
        {
            cupboardRightAnim.SetBool("isDoorOpen", false);
            isDoorOpen = false;
        }
    }



}
