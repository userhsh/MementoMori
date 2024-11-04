using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPrevention : MonoBehaviour
{
    private Vector3 collisionPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("WALL"))
        {
            collisionPosition = this.gameObject.transform.position;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("WALL"))
        {
            this.gameObject.transform.position = collisionPosition;
        }
    }
}