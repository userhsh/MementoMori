using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetRackCase : MonoBehaviour
{
    Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        animator.SetTrigger("CabinetClick");
        Destroy(gameObject, 1f);
    }

}
