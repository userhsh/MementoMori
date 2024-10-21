using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBlood : MonoBehaviour, IInteractable
{
    PaperName paperName = null; //이름 적힐 종이
    SpriteRenderer nameElie = null; //이름
    Collider otherCollider = null;
    bool isTrue = false;

    bool isPencilInteractable = false;

    public Collider bloodCollider = null;

    private void Awake()
    {
        paperName = GetComponentInChildren<PaperName>();
        nameElie = GetComponentInChildren<SpriteRenderer>();
        nameElie.enabled = false; //이름 먼저 가져와서 꺼둔 후에
        paperName.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Paper_None")
        {
            Destroy(other?.gameObject); //빈 종이 삭제
            bloodCollider.gameObject.SetActive(false);
            paperName.gameObject.SetActive(true); //이름 종이 출현
        }

        if (paperName.gameObject.activeSelf && other.gameObject.name == "Pencil")
        {
            isPencilInteractable = true;
        }

        if (other.gameObject.layer == 1 >> 10) return;

        otherCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pencil")
        {
            isPencilInteractable = false;
        }

        otherCollider = null;
    }

    public void Interact()
    {
        if (!isPencilInteractable) return;

        isTrue = true;
        Destroy(otherCollider?.gameObject);
        nameElie.enabled = true; //이름 출현
        this.gameObject.name = "Collection2";
    }

    public void Collection2Get()
    {
        if (isTrue)
        {
            GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[1] = true;
            this.gameObject.SetActive(false);
        }
    }

}