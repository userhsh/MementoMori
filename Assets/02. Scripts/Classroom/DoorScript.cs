using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorScript : MonoBehaviour
{
    private AudioClip openSound;
    private AudioClip closeSound;

    private AudioSource audioSource;  // ����� �ҽ�
    private XRGrabInteractable grabInteractable;

    bool isOpen = false;
    Animator animator;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        openSound = Resources.Load<AudioClip>("DoorSound/doorOpen");
        closeSound = Resources.Load<AudioClip>("DoorSound/doorClose");

        // ��ü�� ���� �� ȣ��Ǵ� �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(OpenCaseDoor);
    }

    public void OpenCaseDoor(SelectEnterEventArgs args)
    {
        if (isOpen == false)
        {
            isOpen = true;
            animator.SetBool("isOpen", true);

            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.7f);
        }
        else
        {
            isOpen = false;
            animator.SetBool("isOpen", false);

            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.4f);
        }
    }
}
