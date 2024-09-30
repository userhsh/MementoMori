using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickManager : MonoBehaviour
{
    public GameObject switchButton;
    public MedRackDoor[] medRackDoorlock;

    private void Awake()
    {

    }

   public void MedRackDoorLock()
    {

        for (int i = 0; i < medRackDoorlock.Length; i++)
        {
            medRackDoorlock[i].DoorLock = false;
        }
    }
}
