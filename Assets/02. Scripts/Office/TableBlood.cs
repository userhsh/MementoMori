using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBlood : MonoBehaviour, IInteractable
{
    PaperNone paperNone = null; //Ƽ�� �� ȹ��� ������
    PaperName paperName = null; //�̸� ���� ����
    Pencil pencil = null;
    SpriteRenderer nameElie = null; //�̸�
    bool isTrue = false;

    private void Awake()
    {
        paperName = GetComponentInChildren<PaperName>();
        nameElie = GetComponentInChildren<SpriteRenderer>();
        nameElie.enabled = false; //�̸� ���� �����ͼ� ���� �Ŀ�
        paperName.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        paperNone = other.gameObject.GetComponent<PaperNone>();
        pencil = other.gameObject.GetComponent<Pencil>();

        if (paperNone != null)
        {
            Destroy(paperNone.gameObject); //�� ���� ����
            paperName.gameObject.SetActive(true); //�̸� ���� ����

            if (paperName.enabled == true && pencil != null) //�̸� ���� ���� ���¿��� ���� ���
            {
                isTrue = true;
                Destroy(pencil.gameObject); //���� ���� ��
                nameElie.enabled = true; //�̸� ����

            }
        }


    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void Collection2Get()
    {
        if (isTrue)
        {
            GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[1] = true;
        }
    }

}
