using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemCrowBar : MonoBehaviour
{
   public bool use = false;

    public GameObject strangeTile;
    public GameObject switchButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "StrangeTile")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "StrangeTile")
        {
            use = false;
        }
    }

   public void Use()
    {
        if (use == true)
        {
            print("크로우바 사용");
            strangeTile.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            switchButton.GetComponent<BoxCollider>().enabled = true;
        }      
    }
}
