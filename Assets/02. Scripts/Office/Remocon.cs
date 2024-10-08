using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Remocon : MonoBehaviour, IUseable
{
    IInteractable interactable = null;

    TV TV = null;

    private void Awake()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        TV = other.gameObject.GetComponent<TV>();
        interactable = other.gameObject.GetComponent<IInteractable>();

        if (TV != null)
        {
            interactable?.Interact();
        }
        else
        {
            print("다른 곳에 사용해보자.");
        }

    }


    public void GetItem(Transform _pos)
    {
        print("리모컨 획득");
        //this.gameObject.SetActive(false);
    }


    public void Use(Collider _collider)
    {

    }
}
