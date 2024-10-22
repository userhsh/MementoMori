using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{


    private Transform playerPosition;

    private float truckSpeed = 25f;

    public bool isTruckDestroy = false; //UI 띄우기 위한 트럭 충돌 확인용

    private void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("PLAYER").transform;
    }

    private void Update()
    {
        //플레이어 쪽으로 달려오도록
        Vector3 direction = (playerPosition.position - transform.position).normalized;

        transform.position += direction * truckSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {

        this.gameObject.SetActive(false);
        isTruckDestroy = true;

    }

}
