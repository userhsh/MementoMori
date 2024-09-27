using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HOLE"))
        {
            Debug.Log("수도꼭지 설치완료");
            transform.localPosition = new Vector3(29.557f, 4.972f, -1.0389f);
        }
    }
}
