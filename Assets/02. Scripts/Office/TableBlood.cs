using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBlood : MonoBehaviour, IInteractable
{
    PaperName paperName = null; //�̸� ���� ����
    SpriteRenderer nameElie = null; //�̸�
    Collider otherCollider = null;
    bool isTrue = false;

    bool isPencilInteractable = false;

    private void Awake()
    {
        paperName = GetComponentInChildren<PaperName>();
        nameElie = GetComponentInChildren<SpriteRenderer>();
        nameElie.enabled = false; //�̸� ���� �����ͼ� ���� �Ŀ�
        paperName.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        otherCollider = other;

        if (other.gameObject.name == "Paper_None")
        {
            Destroy(other.gameObject); //�� ���� ����
            paperName.gameObject.SetActive(true); //�̸� ���� ����
        }

        if (paperName.gameObject.activeSelf && other.gameObject.name == "Pencil")
        {
            isPencilInteractable = true;
        }
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
        Destroy(otherCollider.gameObject);
        nameElie.enabled = true; //�̸� ����
    }

    public void Collection2Get()
    {
        if (isTrue)
        {
            GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[1] = true;
        }
    }

}