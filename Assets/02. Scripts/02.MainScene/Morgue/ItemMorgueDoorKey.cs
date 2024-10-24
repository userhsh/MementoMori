using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMorgueDoorKey : MonoBehaviour
{
    public bool use = false;

    public GameObject doorLock;
    public GameObject morgueDoorLeft;
    public GameObject morgueDoorRight;

    private void OnTriggerEnter(Collider other) //����� �ڹ��谡 �浹 �� ��� ���� ����
    {
        if (other.gameObject.name == "DoorLock")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other) //����� �ڹ��谡 �浹�� ��� �� ��� ���� �Ұ���
    {
        if (other.gameObject.name == "DoorLock")
        {
            use = false;
        }
    }

    public void Use() //���� ���
    {
        if (use == true) //��������� �Ǿ��� ��
        {
            //��ü��ġ�� ��/�� �� ��� ����
            morgueDoorLeft.GetComponent<MorgueDoors>().MorgueDoorLock = false;
            morgueDoorRight.GetComponent<MorgueDoors>().MorgueDoorLock = false;

            //�ڹ���, ��ü��ġ�� ���� ��Ȱ��
            doorLock.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
