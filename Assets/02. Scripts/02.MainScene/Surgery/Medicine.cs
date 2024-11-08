using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Medicine : MonoBehaviour, IInteractable
{
    public Fabric fabric;
    public MedicineFabric medicineFabric;
    bool isInteractable = false;
    private AudioSource audioSource;
    private AudioClip WetSound;
    private MeshRenderer meshRenderer;
    private Collider collider;

    private void Awake()
    {
        medicineFabric.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }
    private void Start()
    {
        WetSound = Resources.Load<AudioClip>("SurgerySFX/WetSound");
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "PillowFabic")
        {
            isInteractable = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "PillowFabic")
        {
            isInteractable = false;
        }
    }

    public void Interact()
    {
        if (!isInteractable) return;

        audioSource.PlayOneShot(WetSound);
        // 천 제거
        Destroy(fabric.gameObject);
        // 약품 안보이게
        meshRenderer.enabled = false;
        collider.enabled = false;
        medicineFabric.gameObject.SetActive(true);
    }
}