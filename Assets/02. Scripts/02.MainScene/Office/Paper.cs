using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IUseable
{
    public void GetItem(Transform _pos)
    {
        print("������ ȹ��");
        this.gameObject.SetActive(false);
    }

    public void Use(Collider _collider)
    {
        throw new System.NotImplementedException();
    }

}
