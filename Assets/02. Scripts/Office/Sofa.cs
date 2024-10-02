using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Sofa : MonoBehaviour, IInteractable
{
    Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            Debug.Log(other.gameObject.name);
            Interact();
        }
    }

    public void Interact()
    {
        animator.SetTrigger("SofaClick");
        Destroy(gameObject, 1f);
    }


}
