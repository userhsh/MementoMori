using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMorgueDoorKey : MonoBehaviour
{
    public bool use = false;

    public GameObject doorLock;
    public GameObject morgueDoorLeft;
    public GameObject morgueDoorRight;

    private void OnTriggerEnter(Collider other) //열쇠와 자물쇠가 충돌 시 사용 조건 가능
    {
        if (other.gameObject.name == "DoorLock")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other) //열쇠와 자물쇠가 충돌을 벗어날 시 사용 조건 불가능
    {
        if (other.gameObject.name == "DoorLock")
        {
            use = false;
        }
    }

    public void Use() //열쇠 사용
    {
        if (use == true) //사용조건이 되었을 때
        {
            //시체안치실 왼/오 문 잠김 해제
            morgueDoorLeft.GetComponent<MorgueDoors>().MorgueDoorLock = false;
            morgueDoorRight.GetComponent<MorgueDoors>().MorgueDoorLock = false;

            //자물쇠, 시체안치실 열쇠 비활성
            doorLock.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
