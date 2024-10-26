using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour, IUseable
{
    Doll doll = null;

    bool isSelect = false;

    private void OnCollisionEnter(Collision collision)
    {
        Use(collision.collider);
    }

    public void GetItem(Transform _pos)
    {
        transform.SetParent(_pos);
        transform.position = _pos.position;
    }

    public void Use(Collider _collider)
    {
        if (!isSelect) return;

        doll = _collider.gameObject.GetComponent<Doll>();

        doll?.Interact();
    }

    public void OnSelectEnter()
    {
        isSelect = true;
    }

    public void OnSelectExit()
    {
        isSelect = false;
    }
}