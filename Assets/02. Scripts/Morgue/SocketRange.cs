using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketRange : MonoBehaviour
{
    Transform socketTransform;
    [Range(-0.3f, 0.3f)]
    public float leftAndRight = 0;

    private void Start()
    {
        socketTransform = this.gameObject.GetComponentInParent<Transform>();
        this.transform.position = socketTransform.position - new Vector3(leftAndRight, 0, 0);
    }
}
