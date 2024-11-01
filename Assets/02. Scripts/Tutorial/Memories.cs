using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip collectionSound;
    private SpriteRenderer spriteRenderer;
    private Collider collider;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        collectionSound = Resources.Load<AudioClip>("CollectionSound/collectionSound");
    }

    public void Collection0Get()
    {
        audioSource.PlayOneShot(collectionSound);
        GameObject.Find("PlayerUI").GetComponent<TUIManager>().collections = true;
        spriteRenderer.enabled = false;
        collider.enabled = false;
    }
}
