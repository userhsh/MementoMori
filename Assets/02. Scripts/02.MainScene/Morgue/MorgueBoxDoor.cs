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

    public void MogueBoxDoorOpenClose() //��ü������ �ִϸ��̼����� ����ݴ� �޼���
    {
        if (DoorOpen == false)
        {
            //�� ���� �ִϸ��̼� ����
            this.animator.SetBool("DoorOpen", true);
            DoorOpen = true;
            audioSource.clip = BoxDoorOpen;
            audioSource.PlayDelayed(0f);
        }
        else //�� ������ �� ��ȣ�ۿ� ��
        {
            //�� �ݱ� �ִϸ��̼� ����
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
        // ����/���� ���¿� ���� �ִϸ��̼� ����
        animator.SetBool("DoorOpen", DoorOpen);
    }
}
