using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // 셔터를 담을 변수 선언
    public Shutter shutter = null;
    
    public void Interact()
    {
        // 셔터 제거 메서드 실행
        shutter.gameObject.SetActive(false);
    }
}