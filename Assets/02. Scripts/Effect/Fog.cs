using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    private Groove1 groove1;

    private void Awake()
    {
        groove1 = FindObjectOfType<Groove1>();
    }

    private void Start()
    {
        StartCoroutine(FogOff());
    }

    IEnumerator FogOff()
    {
        while (!groove1.isFog)
        {
            yield return null;
        }

        this.gameObject.SetActive(false);
    }
}