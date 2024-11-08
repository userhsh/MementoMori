using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    private bool DoorOpen = false;
    private Animator animator;
    private AudioSource audioSource;
    private AudioClip TableOpen;
    private AudioClip TableClose;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("DoorOpen", false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        TableOpen = Resources.Load<AudioClip>("TutorialSFX/TableSound/TableOpen");
        TableClose = Resources.Load<AudioClip>("TutorialSFX/TableSound/TableClose");
    }

    public void DrawerOpenClose() //��ü������ �ִϸ��̼����� ����ݴ� �޼���
    {
        if (DoorOpen == false)
        {
            //�� ���� �ִϸ��̼� ����
            this.animator.SetBool("DoorOpen", true);
            DoorOpen = true;
            audioSource.PlayOneShot(TableOpen);
        }
        else //�� ������ �� ��ȣ�ۿ� ��
        {
            //�� �ݱ� �ִϸ��̼� ����
            this.animator.SetBool("DoorOpen", false);
            DoorOpen = false;
            audioSource.PlayOneShot(TableClose);
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
