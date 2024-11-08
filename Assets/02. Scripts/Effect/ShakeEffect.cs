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

    private void OnTriggerEnter(Collider other)
    {
        if (soundCount > 2) return;

        if (other.gameObject.CompareTag("PLAYER"))
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}