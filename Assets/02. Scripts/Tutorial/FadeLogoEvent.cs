using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLogoEvent : MonoBehaviour
{
    TLeftController TleftController;
    
    public void Warp() //�ӽ������� Ŭ������� �̵�, ��Ʈ�ѷ� ǥ��X
    {
        GameObject.Find("Player").transform.position = new Vector3(0, -1.5f, 0); 
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
    }

    public void NextScene()
    {
        TleftController.RemoveEvent(); //��� ����       
    }
}
