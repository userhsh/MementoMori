using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTriggerRayOffRight : MonoBehaviour
{
    TRightController trightController;

    private void Start()
    {
        trightController = this.transform.parent.GetComponent<TRightController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("WALL"))
        {
            trightController.GetComponent<TRightController>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WALL"))
        {
            trightController.GetComponent<TRightController>().enabled = true;
        }
    }
}
