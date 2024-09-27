using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            animator.SetBool("isOpen", true);
            Debug.Log("문이 열렸습니다");
        }
    }
}