using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueBoxDoor : MonoBehaviour
{
    Animator animator;
    bool DoorOpen = false;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false);     
    }

    public void MogueBoxDoorOpenClose() //시체보관문 애니메이션으로 열고닫는 메서드
    {
        if (DoorOpen == false)
        {
            //문 열기 애니메이션 실행
            this.animator.SetBool("DoorOpen", true);
            DoorOpen = true;
        }
        else //문 열렸을 때 상호작용 시
        {
            //문 닫기 애니메이션 실행
            this.animator.SetBool("DoorOpen", false);
            DoorOpen = false;
        }
    }
   
}
