using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IUseable
{

    Light light = null;

    private void Awake()
    {
        light = GetComponentInChildren<Light>();
        light.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            light.enabled = true;
        }
    }


    public void GetItem(Transform _pos)
    {
        print("¼ÕÀüµî È¹µæ");
        this.gameObject.SetActive(false);  
    }

    public void Use(Collider _collider)
    {
        throw new System.NotImplementedException();
    }


}
