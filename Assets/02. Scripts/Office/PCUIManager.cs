using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PCUIManager : MonoBehaviour
{
    Antlers antlers = null;
    ComputerUI computerUI = null;

    private void Awake()
    {
        antlers = GameObject.FindObjectOfType<Antlers>();
        computerUI = GetComponentInChildren<ComputerUI>();

        computerUI.ComputerUIInit();

        computerUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        OnComputer();
    }

    private void OnComputer()
    {
        if (antlers.InteractionCount % 4 == 2)
        {
            computerUI.gameObject.SetActive(true);
        }
        else
        {
            computerUI.gameObject.SetActive(false);
        }
    }
}