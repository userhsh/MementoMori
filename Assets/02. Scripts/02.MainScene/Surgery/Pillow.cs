using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pillow : MonoBehaviour, IInteractable
{
    public Fabric fabric;

    bool isInteractable = false;

    AudioSource audioSource;
    [SerializeField]
    AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        fabric.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Scalpel")
        {
            isInteractable = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Scalpel")
        {
            isInteractable = false;
        }
    }

    public void Interact()
    {
        if (!isInteractable) return;

        if (isInteractable)
        {
            audioSource.PlayOneShot(clip);
            isInteractable = false;
        }
        // 玫 积己
        fabric.gameObject.SetActive(true);
        // 海俺 力芭
        Destroy(gameObject, clip.length);
    }
}