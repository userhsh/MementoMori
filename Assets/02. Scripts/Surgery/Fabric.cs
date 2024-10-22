using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabric : MonoBehaviour, IUseable
{
    // ��ǰ ���� ���� ����
    Medicine medicine = null;

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
            // _collider�� medicine ��������
            medicine = _collider.gameObject.GetComponent<Medicine>();
            // medicine�� ���ٸ� 
            if (medicine == null)
            {
                // �޼��� ����������
                return;
            }
            // medicine�� �����Ѵٸ� Interact ����
            medicine?.Interact();
            // õ ���� �ֱ�
            Destroy(this.gameObject);
        }
    }
}