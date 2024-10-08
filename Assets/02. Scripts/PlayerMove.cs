using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    IInteractable interactable = null;

    float moveSpeed = 10f;

    void FixedUpdate()
    {
        PlayerMovement();
        Dash();
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        interactable = other.gameObject.GetComponent<IInteractable>();
        interactable?.Interact();
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.gameObject.transform.Rotate(0, 90, 0);
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

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}