using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockers : MonoBehaviour
{
    private Animator animator;
    bool DoorOpen = false;
    private AudioSource audioSource;
    private AudioClip FileCabinetOpen;
    private AudioClip FileCabinetClose;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        FileCabinetOpen = Resources.Load<AudioClip>("TutorialSFX/FileCabinetSound/FileCabinetOpen");
        FileCabinetClose = Resources.Load<AudioClip>("TutorialSFX/FileCabinetSound/FileCabinetClose");
    }

    public void LockerOpenClose() //시체보관문 애니메이션으로 열고닫는 메서드
    {
        if (DoorOpen == false)
        {
            //문 열기 애니메이션 실행
            this.animator.SetBool("DoorOpen", true);
            DoorOpen = true;
            audioSource.PlayOneShot(FileCabinetOpen);
        }
        else //문 열렸을 때 상호작용 시
        {
            //문 닫기 애니메이션 실행
            this.animator.SetBool("DoorOpen", false);
            DoorOpen = false;
            audioSource.PlayOneShot(FileCabinetClose);
        }
    }

    public void Animationing()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.transform.GetChild(0).GetComponent<Collider>().enabled = false;
    }
    public void AnimationEnd()
    {
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.transform.GetChild(0).GetComponent<Collider>().enabled = true;
    }
}
