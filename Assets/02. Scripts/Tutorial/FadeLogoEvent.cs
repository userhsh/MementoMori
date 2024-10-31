using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLogoEvent : MonoBehaviour
{
    TLeftController TleftController;
    
    public void Warp() //임시적으로 클리어공간 이동, 컨트롤러 표시X
    {
        GameObject.Find("Player").transform.position = new Vector3(0, -1.5f, 0); 
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
    }

    public void NextScene()
    {
        TleftController.RemoveEvent(); //펑션 삭제       
    }
}
