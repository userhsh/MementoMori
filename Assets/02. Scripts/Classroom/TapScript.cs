using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScript : MonoBehaviour
{
    bool isTurnOn = false;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HOLE"))
        {
            Debug.Log("수도꼭지 장착");
            transform.localPosition = new Vector3(-0.014f, 1.158f, 0.404f);
        }
        if (other.CompareTag("PLAYER"))
        {
            Debug.Log("수도꼭지 틀기");
            animator.SetBool("isTurnOn", true);
        }
    }
}
