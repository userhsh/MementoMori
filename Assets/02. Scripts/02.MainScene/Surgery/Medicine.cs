using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Medicine : MonoBehaviour, IInteractable
{
    public Fabric fabric;
    public MedicineFabric medicineFabric;

    bool isInteractable = false;

    private void Awake()
    {
        medicineFabric.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PillowFabic")
        {
            isInteractable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "PillowFabic")
        {
            isInteractable = false;
        }
    }

    public void Interact()
    {
        if (!isInteractable) return;

        // 약 묻은 천 생성
        medicineFabric.gameObject.SetActive(true);
        Destroy(fabric.gameObject);
        // 약품 제거
        Destroy(gameObject);
    }
}