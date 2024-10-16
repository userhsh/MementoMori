using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pillow : MonoBehaviour, IInteractable
{
    public Fabric fabric;

    bool isInteractable = false;

    private void Awake()
    {
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

        // õ ����
        fabric.gameObject.SetActive(true);
        // ���� ����
        Destroy(gameObject);
    }
}