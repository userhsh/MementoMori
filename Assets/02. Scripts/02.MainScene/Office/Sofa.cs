using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Sofa : MonoBehaviour, IInteractable
{
    Animator animator = null;
    private AudioSource audioSource;
    private AudioClip SofaSFX;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SofaSFX = Resources.Load<AudioClip>("OfficeSFX/SofaSFX");
    }

    public void Interact()
    {
        this.gameObject.GetComponent<Animator>().enabled = true;
        audioSource.PlayOneShot(SofaSFX);
        Destroy(gameObject, 2f);
    }


}
