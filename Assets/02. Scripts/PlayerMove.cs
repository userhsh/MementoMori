using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed = 5f;

    void FixedUpdate()
    {
        PlayerMovement();
        Dash();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, moveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, -moveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime);
        }
    }

    private void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            moveSpeed = 10;
        }
        else
        {
            moveSpeed = 5;
        }
    }
}