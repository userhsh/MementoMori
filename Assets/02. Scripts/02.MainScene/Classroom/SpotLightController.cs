using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    private Light spotLight;
    private float blinkInterval = 0.5f;
    private Coroutine blinkCoroutine;

    private void Start()
    {
        spotLight = GetComponent<Light>();
        blinkCoroutine = StartCoroutine(BlinkLight());
    }

    private IEnumerator BlinkLight()
    {
        while (true)
        {
            spotLight.enabled = !spotLight.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void StopBlinking()
    {
        StopCoroutine(blinkCoroutine);
    }
}
