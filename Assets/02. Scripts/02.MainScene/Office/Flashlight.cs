using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //IInteractable interactable = null;

    Light flashLight = null;

    public float interactionDistance = 2f;

    public GameObject Collection1;
    public GameObject range;

    private void Awake()
    {
        flashLight = GetComponentInChildren<Light>();
        flashLight.enabled = false;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("RANGE"))
            {
                if (flashLight.enabled == true)
                {                  
                    Collection1.SetActive(true);
                }
            }
        }
    }

    public void LightOnOff()
    {
        if (flashLight.enabled == false)
        {
            flashLight.enabled = true;
        }
        else
        {
            flashLight.enabled = false;
        }
    }
}
