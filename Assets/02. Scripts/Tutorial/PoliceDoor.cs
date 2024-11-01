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

    public bool policeDoorLock = true; //�� ��� Ȱ��
    public GameObject lockIcon;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false); //�ִϸ��̼� �Ķ���� DoorOpen

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        doorOpen = Resources.Load<AudioClip>("DoorSound/doorOpen");
        doorClose = Resources.Load<AudioClip>("DoorSound/doorClose");
    }

    public void PoliceDoorOpenClose() //��ǰ���ݹ� �ִϸ��̼����� ����ݴ� �޼���
    {
        if (policeDoorLock == false) //����� Ǯ���� ��
        {
            if (DoorOpen == false) //�� ������ �� ��ȣ�ۿ� ��
            {
                //�� ���� �ִϸ��̼� ����
                this.animator.SetBool("DoorOpen", true);
                DoorOpen = true;
                audioSource.PlayOneShot(doorOpen);
            }
            else //�� ������ �� ��ȣ�ۿ� ��
            {
                //�� �ݱ� �ִϸ��̼� ����
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
