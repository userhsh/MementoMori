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

   
    public void Interact()
    {
        print("½îÆÄ »ç¶óÁü");
        this.gameObject.GetComponent<Animator>().enabled = true;
        Destroy(gameObject, 2f);
    }


}
