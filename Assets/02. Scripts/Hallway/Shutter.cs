using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    ShutterPrice[] shutterPrices = null;

    private void Awake()
    {
        shutterPrices = GetComponentsInChildren<ShutterPrice>();
    }

    IEnumerator DestroyShutterCo()
    {
        for (int i = 0; i < shutterPrices.Length; i++)
        {
            shutterPrices[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }
}