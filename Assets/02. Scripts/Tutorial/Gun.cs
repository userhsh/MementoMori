using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public bool foolAmmo = false;

   public void DontShot()
    {
        if(foolAmmo == true)
        {
            //"¾ÆÁ÷Àº ½ò¼ö ¾ø´Ù.." ´ë»ç ÀÛ¿ë
            print("¾ÆÁ÷Àº ¸ø½ð´Ù.");
        }
        else
        {
            //ºó ÅºÃ¢ »ç¿ë È¿°úÀ½("Ã¶ÄÀ!") Àû¿ë
            print("Ã¶ÄÀ!");
        }
    }
}
