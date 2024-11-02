using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MorgueBoxDoor : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip BoxDoorOpen;
    private AudioClip BoxDoorClose;

    Animator animator;
    public bool DoorOpen = false;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        BoxDoorOpen = Resources.Load<AudioClip>("DoorSound/BoxDoorOpen");
        BoxDoorClose = Resources.Load<AudioClip>("DoorSound/BoxDoorClose");
    }

    public void MogueBoxDoorOpenClose() //시체보관문 애니메이션으로 열고닫는 메서드
    {
        if (DoorOpen == false)
        {
            //문 열기 애니메이션 실행
            this.animator.SetBool("DoorOpen", true);
            DoorOpen = true;
            audioSource.clip = BoxDoorOpen;
            audioSource.PlayDelayed(0f);
        }
        else //문 열렸을 때 상호작용 시
        {
            //문 닫기 애니메이션 실행
            this.animator.SetBool("DoorOpen", false);
            DoorOpen = false;
            audioSource.clip = BoxDoorClose;
            audioSource.PlayDelayed(1.5f);
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

    public void InteractionText()
    {
        GetComponentInChildren<GameObject>().SetActive(true);
    }

    public void UpdateMorgueBoxDoorState()
    {
        // 열림/닫힘 상태에 따라 애니메이션 설정
        animator.SetBool("DoorOpen", DoorOpen);
    }
}
