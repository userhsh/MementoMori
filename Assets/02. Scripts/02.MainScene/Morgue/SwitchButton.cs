using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public MedRackDoor[] medRackDoorlock;
    private AudioSource audioSource;
    private AudioClip MedRackDoorUnlock;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MedRackDoorUnlock = Resources.Load<AudioClip>("MorgueSFX/DoorSound/MedRackDoorUnlock");
    }

    public void MedRackDoorLock()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("ButtonClick", true);
        for (int i = 0; i < medRackDoorlock.Length; i++)
        {
            medRackDoorlock[i].MedRackDoorLock = false;
        }

        audioSource.PlayOneShot(MedRackDoorUnlock);
    }
}
