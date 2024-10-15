using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorScript : MonoBehaviour
{
    private AudioClip openSound;
    private AudioClip closeSound;

    private AudioSource audioSource;  // 오디오 소스
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

        // 물체를 잡을 때 호출되는 이벤트 연결
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
