using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedRackDoor : MonoBehaviour
{
    Animator animator;
   public bool DoorLock = true; //�� ��� Ȱ��
    bool DoorOpen = false;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false); //�ִϸ��̼� �Ķ���� DoorOpen
    }

    public void MedRackDoorOpenClose() //��ǰ���ݹ� �ִϸ��̼����� �����ݴ� �޼���
    {
        if (DoorLock == false) //����� Ǯ���� ��
        {
            if (DoorOpen == false) //�� ������ �� ��ȣ�ۿ� ��
            {
                //�� ���� �ִϸ��̼� ����
                this.animator.SetBool("DoorOpen", true);
                DoorOpen = true;
            }
            else //�� ������ �� ��ȣ�ۿ� ��
            {
                //�� �ݱ� �ִϸ��̼� ����
                this.animator.SetBool("DoorOpen", false);
                DoorOpen = false;
            }
        }

    }

}