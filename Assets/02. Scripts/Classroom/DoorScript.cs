using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private AudioSource audioSource;  // 오디오 소스
    public AudioClip openSound;      // 문 열리는 소리
    public AudioClip closeSound;     // 문 닫히는 소리

    bool isOpen = false;
    Animator animator;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void OpenCaseDoor()
    {
        if (isOpen == false)
        {
            animator.SetBool("isOpen", true);
            isOpen = true;
            // 문 열리는 소리 재생
            audioSource.PlayOneShot(openSound);
        }
        else
        {
            animator.SetBool("isOpen", false);
            isOpen = false;
            // 문 닫히는 소리 재생
            audioSource.PlayOneShot(closeSound);
        }
    }
}