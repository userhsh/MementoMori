using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public NumberInput numberInput;

    private void Start()
    {
        StartCoroutine(FogOff());
    }

    IEnumerator FogOff()
    {
        while (!numberInput.IsCorrect)
        {
            yield return null;
        }

        this.gameObject.SetActive(false);
    }
}