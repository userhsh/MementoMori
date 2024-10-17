using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDist : MonoBehaviour
{
    public Transform cameraOffset;
    public float offsetDist = 1;

    void Update()
    {
        Vector3 offSetPosition = new Vector3(cameraOffset.position.x, this.transform.position.y, cameraOffset.position.z);

        transform.position = offSetPosition;
    }
}
