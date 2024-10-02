using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCamOffet : MonoBehaviour
{
    public Transform cameraOffset;
    public float offsetDist = 1;

    void Update()
    {
        this.transform.position = cameraOffset.position - new Vector3(0, offsetDist, 0);
        this.transform.rotation = cameraOffset.rotation;
    }
}
