using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // ���͸� ���� ���� ����
    public Shutter shutter = null;

   public int soundCount = 0;

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

        if (soundCount == 0) 
        {
            audioSource.PlayOneShot(clip);
        }

        // ���� ���� �޼��� ����
        shutter.gameObject.SetActive(false);

        soundCount++;
    }
}