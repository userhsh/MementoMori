using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueDoors : MonoBehaviour
{
    Animator animator;
    public bool MorgueDoorLock = true; //문 잠김 활성
    bool DoorOpen = false;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false); //애니메이션 파라미터 DoorOpen
    }

    public void MorgueDoorsOpenClose() //약품선반문 애니메이션으로 열고닫는 메서드
    {
        if (MorgueDoorLock == false) //잠김이 풀렸을 때
        {
            if (DoorOpen == false) //문 닫혔을 때 상호작용 시
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

    public void Animationing()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
    }
    public void AnimationEnd()
    {
        this.gameObject.GetComponent<Collider>().enabled = true;
    }
}
