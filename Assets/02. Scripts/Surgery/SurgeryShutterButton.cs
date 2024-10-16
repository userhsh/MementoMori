using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // ���͸� ���� ���� ����
    Shutter shutter = null;

    private void Awake()
    {
        SurgeryShutterButtonInit();
    }

    // ���� �������� �޼���
    private void SurgeryShutterButtonInit()
    {
        shutter = GameObject.FindObjectOfType<Shutter>();
    }
    
    public void Interact()
    {
        // ���� ���� �޼��� ����
        shutter.DestroyShutter();
    }
}