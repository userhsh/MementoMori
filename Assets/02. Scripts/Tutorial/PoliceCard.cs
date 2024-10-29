using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCard : MonoBehaviour
{
 
    public void GripCard()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.gameObject.transform.SetParent(null);
    }
    
}
