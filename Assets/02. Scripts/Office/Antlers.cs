using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Antlers : MonoBehaviour, IInteractable
{
    int interactionCount = 0;
    public int InteractionCount { get { return interactionCount; } }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("PLAYER"))
        {
            Interact();
        }
    }

    public void Interact()
    {
        transform.Rotate(0, 0, 90);
        interactionCount++;
    }
}