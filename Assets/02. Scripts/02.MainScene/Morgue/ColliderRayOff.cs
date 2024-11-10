using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRayOff : MonoBehaviour
{
    RightController rightController;

    private void Start()
    {
        rightController = this.transform.parent.GetComponent<RightController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("WALL"))
        {
            rightController.GetComponent<RightController>().enabled = false;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WALL"))
        {
            rightController.GetComponent<RightController>().enabled = true;
        }
    }
}
