using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTriggerRayOffLeft : MonoBehaviour
{
    TLeftController tLeftController;

    private void Start()
    {
        tLeftController = this.transform.parent.GetComponent<TLeftController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("WALL"))
        {
            tLeftController.GetComponent<TLeftController>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WALL"))
        {
            tLeftController.GetComponent<TLeftController>().enabled = true;
        }
    }
}
