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
            //"������ ��� ����.." ��� �ۿ�
            print("������ �����.");
        }
        else
        {
            //�� źâ ��� ȿ����("ö��!") ����
            print("ö��!");
        }
    }
}
