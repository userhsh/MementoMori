using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPaper : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Collider collider;
    private AudioSource audioSource;
    private AudioClip collectionSound;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        collectionSound = Resources.Load<AudioClip>("TutorialSFX/PaperSFX");
    }

    public void GetCollection()
    {
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[3] = true;
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collectTalkCount++;
        GameObject.Find("PlayerUI").GetComponent<UIManager>().CollectGetTalkCount();

        audioSource.PlayOneShot(collectionSound);
        meshRenderer.enabled = false;
        collider.enabled = false;
    }
}