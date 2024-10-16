using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryShutterButton : MonoBehaviour, IInteractable
{
    // 셔터를 담을 변수 선언
    Shutter shutter = null;

    private void Awake()
    {
        SurgeryShutterButtonInit();
    }

    // 셔터 가져오는 메서드
    private void SurgeryShutterButtonInit()
    {
        shutter = GameObject.FindObjectOfType<Shutter>();
    }
    
    public void Interact()
    {
        // 셔터 제거 메서드 실행
        shutter.DestroyShutter();
    }
}