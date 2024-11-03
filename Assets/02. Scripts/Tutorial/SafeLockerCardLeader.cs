using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SafeLockerCardLeader : MonoBehaviour
{
    private MeshRenderer cardMechineRenderer;
    private AudioSource audioSource;
    private AudioClip Unlock;
    private AudioClip SafeOpen;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        cardMechineRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Unlock = Resources.Load<AudioClip>("TutorialSFX/SafeLockerSound/Unlock"); // UnlockIndex
        SafeOpen = Resources.Load<AudioClip>("TutorialSFX/SafeLockerSound/SafeOpen"); // SafeOpenIndex
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PoliceCard")
        {
            LockOn();
            GameObject.Find("SafeLockerDoor").GetComponent<Animator>().enabled = true;
            audioSource.PlayOneShot(Unlock);
            collision.gameObject.SetActive(false);
        }

    }

    public void LockOn()
    {
        cardMechineRenderer.material.SetColor("_EmissionColor", Color.green);
        audioSource.clip = SafeOpen;
        audioSource.PlayDelayed(2f);
    }
}
