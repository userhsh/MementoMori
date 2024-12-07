using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    Light pointLight = null;
    Renderer lampRenderer = null;

    int lightValue = 0;

    bool isBroken = false;

    private void Awake()
    {
        pointLight = GetComponentInChildren<Light>();
        lampRenderer = GetComponent<Renderer>();
    }

    private void Start() 
    {
        StartCoroutine(FlashLight());
    }

    IEnumerator FlashLight()
    {
        while (!isBroken)
        {
            GetRandomLightValue();

            if (lightValue == 0)
            {
                pointLight.gameObject.SetActive(true);
                lampRenderer.material.EnableKeyword("_EMISSION");
                yield return new WaitForSeconds(5f);
            }
            else
            {
                pointLight.gameObject.SetActive(false);
                lampRenderer.material.DisableKeyword("_EMISSION");
                yield return new WaitForSeconds(0.35f);
            }
        }
    }

    private void GetRandomLightValue()
    {
        if (lightValue == 0)
        {
            lightValue = 1;
        }
        else
        {
            lightValue = Random.Range(0, 2);
        }
    }
}