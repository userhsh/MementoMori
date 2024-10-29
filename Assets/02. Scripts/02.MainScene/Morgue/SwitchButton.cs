using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public MedRackDoor[] medRackDoorlock;

    public void MedRackDoorLock()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("ButtonClick", true);
        for (int i = 0; i < medRackDoorlock.Length; i++)
        {
            medRackDoorlock[i].MedRackDoorLock = false;
        }
    }
}
