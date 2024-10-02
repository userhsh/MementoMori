using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Antlers : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Interact();
    }

    public void Interact()
    {
        transform.Rotate(0, 0, 90);
    }
}