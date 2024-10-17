using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // ���͸� ���� ���� ����
    public Shutter shutter = null;
    
    public void Interact()
    {
        // ���� ���� �޼��� ����
        shutter.gameObject.SetActive(false);
    }
}