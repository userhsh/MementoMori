using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    bool clipEquit = false;
    public GameObject gunCylinder;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Gun")
        {
            clipEquit = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Gun")
        {
            clipEquit = false;
        }
    }

    public void GunReload()
    {
        if(clipEquit == true)
        {
            gunCylinder.gameObject.SetActive(true); //총의 실린더에 총알 활성
            GameObject.Find("Gun").GetComponent<Gun>().foolAmmo = true; //총알이 있다고 판단하는 bool값
            GameObject.Find("Gun").name = "GunAmmo";
            this.gameObject.SetActive(false); //탄창 오브젝트 비활성
        }
    }

}
