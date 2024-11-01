using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // 셔터를 담을 변수 선언
    public Shutter shutter = null;

    Animator animator;

    AudioSource audioSource;
    [SerializeField]
    AudioClip clip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        // 애니메이션 실행
        animator.SetTrigger("IsPush");

        audioSource.PlayOneShot(clip);
        // 셔터 제거 메서드 실행
        shutter.gameObject.SetActive(false);
    }
}