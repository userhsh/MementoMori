using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PoliceKey : MonoBehaviour
{
    public bool use = false;

    public void FirstGripKey()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.gameObject.transform.SetParent(null);
    }
        private void OnTriggerEnter(Collider other) //����� �ڹ��谡 �浹 �� ��� ���� ����
    {
        if (other.gameObject.name == "PoliceDoorLock")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other) //����� �ڹ��谡 �浹�� ��� �� ��� ���� �Ұ���
    {
        if (other.gameObject.name == "PoliceDoorLock")
        {
            use = false;
        }
    }

    public void PoliceDoorOpen()
    {
        if(use == true)
        {
            GameObject.Find("PoliceDoor").GetComponent<PoliceDoor>().policeDoorLock = false;
        }
    }
}
