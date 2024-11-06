using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogCollision : MonoBehaviour, IEffectable
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();

        canvas.gameObject.SetActive(false);
    }

    public void TriggerEffect()
    {
        canvas.gameObject.SetActive(true);

        Invoke("OffCanvas", 2f);
    }

    private void OffCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}