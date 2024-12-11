using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public MedRackDoor[] medRackDoorlock;
    public GameObject medRackTriggerRayOff;
    public GameObject medRackLockAudioClip;
    public GameObject buttonSparkEffect;
    private AudioSource audioSource;
    private AudioClip MedRackDoorUnlock;

    int count = 1;

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
        if (count == 1)
        {
            Invoke("MedRackUnlock", 2f);
            buttonSparkEffect.SetActive(true);
            gameObject.GetComponentInChildren<Animator>().SetBool("ButtonClick", true);
            medRackTriggerRayOff.SetActive(false);
            for (int i = 0; i < medRackDoorlock.Length; i++)
            {
                medRackDoorlock[i].MedRackDoorLock = false;
            }

            audioSource.PlayOneShot(MedRackDoorUnlock);
            count--;
        }
    }

    private void MedRackUnlock()
    {
        medRackLockAudioClip.SetActive(true);
    }
}
