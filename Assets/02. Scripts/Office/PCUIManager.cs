using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
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
        if (antlers.transform.localEulerAngles == Vector3.zero)
        {
            computerUI.gameObject.SetActive(true);
        }
        else
        {
            computerUI.gameObject.SetActive(false);
        }
    }
}