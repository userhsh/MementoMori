using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    private Light spotLight;
    private float blinkInterval = 0.5f;
    private Coroutine blinkCoroutine;

    private void Awake()
    {
        spotLight = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            blinkCoroutine = StartCoroutine(BlinkLight());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            StopCoroutine(blinkCoroutine);
        }
    }

    private IEnumerator BlinkLight()
    {
        while (true)
        {
            spotLight.enabled = !spotLight.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
