using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // ���͸� ���� ���� ����
    public Shutter shutter = null;

    public int soundCount = 0;

    Animator animator;

    [SerializeField]
    AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        // �ִϸ��̼� ����
        animator.SetTrigger("IsPush");

        if (soundCount == 0) 
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        // ���� ���� �޼��� ����
        shutter.gameObject.SetActive(false);

        soundCount++;
    }
}