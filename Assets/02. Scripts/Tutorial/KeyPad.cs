using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip SelectSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SelectSound = Resources.Load<AudioClip>("ClickSound/SelectSound");
    }

    public GameObject keypadUI;
    public void KaypadOn()
    {
        audioSource.PlayOneShot(SelectSound);
        keypadUI.SetActive(true);
    }
}
