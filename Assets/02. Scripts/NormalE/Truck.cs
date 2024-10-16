using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{


    private Transform playerPosition;

    private float truckSpeed = 25f;

    public bool isTruckDestroy = false; //UI ���� ���� Ʈ�� �浹 Ȯ�ο�

    private void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("PLAYER").transform;
    }

    private void Update()
    {
        //�÷��̾� ������ �޷�������
        Vector3 direction = (playerPosition.position - transform.position).normalized;

        transform.position += direction * truckSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {

        this.gameObject.SetActive(false);
        isTruckDestroy = true;

    }

}
