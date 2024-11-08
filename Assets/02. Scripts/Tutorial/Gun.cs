using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public TUITalk tUITalk;
    public bool foolAmmo = false; //�Ѿ��� ä������ ��
    public bool dontText = false; //������ ���� ��

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
