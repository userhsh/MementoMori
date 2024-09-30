using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    IInteractable interactObject = null;
    IUseable useableItem = null;

    float moveSpeed = 5f;

    GripPos gripPos = null;

    private void Awake()
    {
        gripPos = GetComponentInChildren<GripPos>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        Dash();
        PlayerRotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        interactObject = other.gameObject.GetComponent<IInteractable>();
        useableItem = other.gameObject.GetComponent<IUseable>();

        interactObject?.Interact();
        useableItem?.GetItem(gripPos.transform);
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

    private void PlayerRotate()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
    }

    private void GripItem()
    {

    }
}