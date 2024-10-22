using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PCUIManager : MonoBehaviour
{
    Antlers antlers = null;
    AudioSource audioSource = null;
    AudioClip clip = null;
    ComputerUI computerUI = null;
    public GameObject computerSound;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("OfficeSFX/button03b");

        antlers = GameObject.FindObjectOfType<Antlers>();
        computerUI = GetComponentInChildren<ComputerUI>();

        computerUI.ComputerUIInit();

        computerUI.gameObject.SetActive(false);

        computerSound.GetComponent<AudioSource>().clip = clip;
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
            if (!audioSource.isPlaying)
            {
                computerSound.GetComponent<AudioSource>().enabled = true;
                //audioSource.PlayOneShot(clip);
            }
               
        }
        else
        {
            computerSound.GetComponent<AudioSource>().enabled = false;
            computerUI.gameObject.SetActive(false);
        }
    }


}