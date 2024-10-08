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

    public void TurnOnWater()
    {
        Debug.Log("수도꼭지 틀기");
        animator.SetBool("isTurnOn", true);
    }
}
