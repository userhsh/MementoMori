using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardLeftMove : MonoBehaviour
{
    Animator cupboardLeftAnim = null;

    bool isDoorOpen = false;


    private void Awake()
    {
        cupboardLeftAnim = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (isDoorOpen == false)
        {
            cupboardLeftAnim.SetBool("isDoorOpen", true);
            isDoorOpen = true;
        }
        else
        {
            cupboardLeftAnim.SetBool("isDoorOpen", false);
            isDoorOpen = false;
        }
    }
}
