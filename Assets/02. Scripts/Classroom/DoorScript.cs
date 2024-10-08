using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    bool isOpen = false;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenCaseDoor()
    {
        if (isOpen == false)
        {
            animator.SetBool("isOpen", true);
            isOpen = true;
        }
        else
        {
            animator.SetBool("isOpen", false);
            isOpen = false;
        }
    }
}