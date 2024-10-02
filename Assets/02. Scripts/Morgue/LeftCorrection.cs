using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCorrection : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        this.transform.position = other.transform.position;
    }
}
