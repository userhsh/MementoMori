using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    GameObject pictureDiary = null;
    private Scalpel scalpel;
    bool isInteractable = false;
    public GameObject devil_doll;
    private Collider collider;

    private void Awake()
    {
        // pictureDiary�� Resources ������ Collection3�� ����
        pictureDiary = Resources.Load("Prefabs/Collection3", typeof(GameObject)) as GameObject;
        scalpel = FindObjectOfType<Scalpel>();
        collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Scalpel")
        {
            isInteractable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Scalpel")
        {
            isInteractable = false;
        }
    }

    public void Interact()
    {
        if (!isInteractable) return;

        // �׸��ϱ� ����
        if (isInteractable)
        {
            scalpel.PlayDollSFX();
            Instantiate(pictureDiary, this.transform.position, this.transform.rotation);
            // ���� ����
            devil_doll.SetActive(false);
            collider.enabled = false;
            isInteractable = false;
        }
    }
}