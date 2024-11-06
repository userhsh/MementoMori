using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public TUITalk tUITalk;
    public bool foolAmmo = false; //총알이 채워졌을 때
    public bool dontText = false; //구역에 들어갔을 떄

    private AudioSource audioSource;
    private Ammo ammo;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ammo = FindObjectOfType<Ammo>();
    }

    public void DontShot()
    {
        if (dontText == false)
        {
            if (foolAmmo == true)
            {
                StartCoroutine(tUITalk.DontShotTalk());              
            }
            else
            {  
                AudioClip ReloadSound = ammo.GetReloadSound();
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(ReloadSound);
                }
            }
        }

    }
}
