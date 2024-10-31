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
        private void OnTriggerEnter(Collider other) //열쇠와 자물쇠가 충돌 시 사용 조건 가능
    {
        if (other.gameObject.name == "PoliceDoorLock")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other) //열쇠와 자물쇠가 충돌을 벗어날 시 사용 조건 불가능
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
