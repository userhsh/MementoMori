using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    GameObject pictureDiary = null;

    bool isInteractable = false;

    private void Awake()
    {
        // pictureDiary�� Resources ������ Collection3�� ����
        pictureDiary = Resources.Load("Prefabs/Collection3", typeof(GameObject)) as GameObject;
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
        Instantiate(pictureDiary, this.transform.position, this.transform.rotation);
        // ���� ����
        Destroy(this.gameObject);
    }
}