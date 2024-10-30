using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLockerCardLeader : MonoBehaviour
{

    MeshRenderer cardMechineRenderer;

    private void Awake()
    {
        cardMechineRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PoliceCard")
        {
            LockOn();
            GameObject.Find("SafeLockerDoor").GetComponent<Animator>().enabled = true;
        }

    }

    public void LockOn()
    {
        cardMechineRenderer.material.SetColor("_EmissionColor", Color.green);
    }
}
