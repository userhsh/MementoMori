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

        // �� ���� õ ����
        medicineFabric.gameObject.SetActive(true);
        Destroy(fabric.gameObject);
        // ��ǰ ����
        Destroy(gameObject);
    }
}