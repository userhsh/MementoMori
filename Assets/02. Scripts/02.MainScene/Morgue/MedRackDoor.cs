using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MedRackDoor : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip MedRackDoorOpen;
    private AudioClip MedRackDoorClose;
    Animator animator;
    public bool MedRackDoorLock = true; //문 잠김 활성
    public bool DoorOpen = false;

    public UITalk uITalk;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false); //애니메이션 파라미터 DoorOpen
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MedRackDoorOpen = Resources.Load<AudioClip>("MorgueSFX/DoorSound/MedRackDoorOpen");
        MedRackDoorClose = Resources.Load<AudioClip>("MorgueSFX/DoorSound/MedRackDoorClose");
    }

    public void MedRackDoorOpenClose() //약품선반문 애니메이션으로 열고닫는 메서드
    {
       

        if (MedRackDoorLock == false) //잠김이 풀렸을 때
        {
            if (DoorOpen == false) //문 닫혔을 때 상호작용 시
            {
                //문 열기 애니메이션 실행
                this.animator.SetBool("DoorOpen", true);
                DoorOpen = true;
                audioSource.clip = MedRackDoorOpen;
                audioSource.PlayDelayed(0.25f);
            }
            else //문 열렸을 때 상호작용 시
            {
                //문 닫기 애니메이션 실행
                this.animator.SetBool("DoorOpen", false);
                DoorOpen = false;
                audioSource.clip = MedRackDoorClose;
                audioSource.PlayDelayed(0.5f);
            }
        }
        else
        {
            StartCoroutine(uITalk.InteractionTalk("잠겨있다..."));
        }

    }

    public void UpdateMedRackDoorState()
    {
        // 열림/닫힘 상태에 따라 애니메이션 설정
        animator.SetBool("DoorOpen", DoorOpen);
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
