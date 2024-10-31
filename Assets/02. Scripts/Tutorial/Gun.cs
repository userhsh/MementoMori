using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public TUITalk tUITalk;

    public bool foolAmmo = false;

   public void DontShot()
    {
        if(foolAmmo == true)
        {
            StartCoroutine(tUITalk.DontShotTalk());
        }
        else
        {
            print("Ã¶ÄÀ!");
        }
    }
}
