using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour, IUseable
{
    private AudioSource audioSource;
    private AudioClip DollSFX;

    Doll doll = null;

    bool isSelect = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        DollSFX = Resources.Load<AudioClip>("SurgerySFX/DollSFX");
    }

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

    public void PlayDollSFX()
    {
        audioSource.PlayOneShot(DollSFX);
    }

    public float DollSFXLength()
    {
        return DollSFX.length;
    }
}