using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour, IShakable
{
    AudioSource audioSource;
    int soundCount = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerEffect()
    {
        if (soundCount != 0) return;

        audioSource.PlayOneShot(audioSource.clip);

        soundCount++;
    }
}