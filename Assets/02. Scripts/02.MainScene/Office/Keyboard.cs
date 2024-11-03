using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    private Button[] keyboardButton = new Button[12]; //1~0, DEL, ENTER
    public Button[] KeyboardButton { get { return keyboardButton; } }
    private AudioSource audioSource;
    private AudioClip ButtonSFX;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ButtonSFX = Resources.Load<AudioClip>("OfficeSFX/ButtonSFX");
        for(int i = 0; i<keyboardButton.Length - 1; i++)
        {
            keyboardButton[i].onClick.AddListener(PlaySound);
        }
    }

    public void KeyboardButtonInit()
    {
        keyboardButton = gameObject.GetComponentsInChildren<Button>();
    }

    private void PlaySound()
    {
        audioSource.PlayOneShot(ButtonSFX);
    }
}