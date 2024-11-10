using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRayOffLeft : MonoBehaviour
{
    LeftController LeftController;

    private void Start()
    {
        LeftController = this.transform.parent.GetComponent<LeftController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("WALL"))
        {
            LeftController.GetComponent<LeftController>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WALL"))
        {
            LeftController.GetComponent<LeftController>().enabled = true;
        }
    }
}
