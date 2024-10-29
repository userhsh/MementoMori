using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // ���͸� ���� ���� ����
    public Shutter shutter = null;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        // �ִϸ��̼� ����
        animator.SetTrigger("IsPush");
        // ���� ���� �޼��� ����
        shutter.gameObject.SetActive(false);
    }
}