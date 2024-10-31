using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour, IEffectable
{
    AudioSource audioSource = null;
    [SerializeField]
    AudioClip clip = null;

    int triggerCount = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerEffect()
    {
        if (triggerCount % 3 == 0)
        {
            audioSource.PlayOneShot(clip);
        }

        triggerCount++;
    }
}