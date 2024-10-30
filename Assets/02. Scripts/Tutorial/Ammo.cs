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
            gunCylinder.gameObject.SetActive(true); //���� �Ǹ����� �Ѿ� Ȱ��
            GameObject.Find("Gun").GetComponent<Gun>().foolAmmo = true; //�Ѿ��� �ִٰ� �Ǵ��ϴ� bool��
            GameObject.Find("Gun").name = "GunAmmo";
            this.gameObject.SetActive(false); //źâ ������Ʈ ��Ȱ��
        }
    }

}
