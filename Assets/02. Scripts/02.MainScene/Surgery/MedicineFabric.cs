using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineFabric : MonoBehaviour, IUseable
{
    // �ſ� ���� ���� ����
    Mirror mirror = null;

    private bool isUse = false;

    public void GetItem(Transform _pos)
    {
        transform.SetParent(_pos);
        transform.position = _pos.position;
    }

    // ����� ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 1 >> 8)
        {
            isUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 1 >> 8)
        {
            isUse = false;
        }
    }

    public void Use(Collider _collider)
    {
        if (isUse)
        {
            // _collider�� mirror�� ��������
            mirror = _collider.gameObject.GetComponent<Mirror>();
            // mirror�� ���� ���
            if (mirror == null)
            {
                // �޼��� ����������
                return;
            }
            // mirror�� �����ϸ� Interact ����
            mirror?.Interact();
        }
    }
}