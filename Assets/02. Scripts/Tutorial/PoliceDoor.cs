using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceDoor : MonoBehaviour
{
    private Animator animator;
    private bool DoorOpen = false;
    private AudioSource audioSource;
    private AudioClip doorOpen;
    private AudioClip doorClose;

    public bool policeDoorLock = true; //문 잠김 활성
    public GameObject lockIcon;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false); //애니메이션 파라미터 DoorOpen

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        doorOpen = Resources.Load<AudioClip>("TutorialSFX/DoorSound/doorOpen");
        doorClose = Resources.Load<AudioClip>("TutorialSFX/DoorSound/doorClose");
    }

    public void PoliceDoorOpenClose() //약품선반문 애니메이션으로 열고닫는 메서드
    {
        if (policeDoorLock == false) //잠김이 풀렸을 때
        {
            if (DoorOpen == false) //문 닫혔을 때 상호작용 시
            {
                //문 열기 애니메이션 실행
                this.animator.SetBool("DoorOpen", true);
                DoorOpen = true;
                audioSource.PlayOneShot(doorOpen);
            }
            else //문 열렸을 때 상호작용 시
            {
                //문 닫기 애니메이션 실행
                this.animator.SetBool("DoorOpen", false);
                DoorOpen = false;
                audioSource.PlayOneShot(doorClose);
            }
        }
        else
        {
            lockIcon.gameObject.SetActive(false);
            lockIcon.gameObject.SetActive(true);
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
