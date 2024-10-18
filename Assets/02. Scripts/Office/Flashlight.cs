using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light flashLight = null;

    private void Awake()
    {
        flashLight = GetComponentInChildren<Light>();
        flashLight.enabled = false;
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