using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public TUITalk tUITalk;
    public bool foolAmmo = false;
    private AudioSource audioSource;
    private Ammo ammo;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ammo = FindObjectOfType<Ammo>();
    }

    public void DontShot()
    {
        if (foolAmmo == true)
        {
            StartCoroutine(tUITalk.DontShotTalk());
            AudioClip ReloadSound = ammo.GetReloadSound();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(ReloadSound);
            }
        }
        else
        {
            print("Ã¶ÄÀ!");
        }
    }
}
