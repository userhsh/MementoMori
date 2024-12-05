using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ramen")
        {
            print("»ç¸Á");
           GameObject.Find("Camera Offset").GetComponent<Rigidbody>().useGravity = true;
            Destroy(other.gameObject, 2f);
        }
    }

    public IEnumerator RamenDie()
    {
        GameObject.Find("Camera Offset").GetComponent<Rigidbody>().useGravity = true;
        yield break;
    }
}
