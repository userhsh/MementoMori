using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // ���͸� ���� ���� ����
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
        // �ִϸ��̼� ����
        animator.SetTrigger("IsPush");

        audioSource.PlayOneShot(clip);
        // ���� ���� �޼��� ����
        shutter.gameObject.SetActive(false);
    }
}