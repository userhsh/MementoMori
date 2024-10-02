using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour
{
   public GameObject LeftHandRender;


   public void LeftHandRenderIdle()
    {
        LeftHandRender.SetActive(true);
    }

   public void LeftHandRenderGripping()
    {
        LeftHandRender.SetActive(false);
    }

    
}
