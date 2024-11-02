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
    public bool MedRackDoorLock = true; //�� ��� Ȱ��
    public bool DoorOpen = false;
    public GameObject lockIcon;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false); //�ִϸ��̼� �Ķ���� DoorOpen
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MedRackDoorOpen = Resources.Load<AudioClip>("DoorSound/MedRackDoorOpen");
        MedRackDoorClose = Resources.Load<AudioClip>("DoorSound/MedRackDoorClose");
    }

    public void MedRackDoorOpenClose() //��ǰ���ݹ� �ִϸ��̼����� ����ݴ� �޼���
    {
        if (MedRackDoorLock == false) //����� Ǯ���� ��
        {
            if (DoorOpen == false) //�� ������ �� ��ȣ�ۿ� ��
            {
                //�� ���� �ִϸ��̼� ����
                this.animator.SetBool("DoorOpen", true);
                DoorOpen = true;
                audioSource.clip = MedRackDoorOpen;
                audioSource.PlayDelayed(0.25f);
            }
            else //�� ������ �� ��ȣ�ۿ� ��
            {
                //�� �ݱ� �ִϸ��̼� ����
                this.animator.SetBool("DoorOpen", false);
                DoorOpen = false;
                audioSource.clip = MedRackDoorClose;
                audioSource.PlayDelayed(0.5f);
            }
        }
        else
        {
            lockIcon.gameObject.SetActive(false);
            lockIcon.gameObject.SetActive(true);
        }

    }

    public void UpdateMedRackDoorState()
    {
        // ��� ���°� ������ ��� ��� ������ �����
        if (!MedRackDoorLock)
        {
            lockIcon?.gameObject.SetActive(false);
        }

        // ����/���� ���¿� ���� �ִϸ��̼� ����
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
