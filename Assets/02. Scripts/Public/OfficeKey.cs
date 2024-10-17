using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeKey : Key
{
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        unlockSound = Resources.Load<AudioClip>("UnlockSound/unlockSound");
    }
}