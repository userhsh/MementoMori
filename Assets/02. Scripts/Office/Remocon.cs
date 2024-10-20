using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Remocon : MonoBehaviour, IUseable
{
    IInteractable interactable = null;

    TV TV = null;

    float rayLength = 2f;

    [SerializeField]
    private LayerMask interactableLayer;

    private void Awake()
    {

    }

    public void DrawRemoconRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, rayLength, interactableLayer))
        {
            TV = hit.collider.GetComponent<TV>();
            interactable = hit.collider.GetComponent<IInteractable>();

            if (TV != null)
            {
                interactable?.Interact();

            }

        }
    }


    public void GetItem(Transform _pos)
    {

    }


    public void Use(Collider _collider)
    {

    }
}
