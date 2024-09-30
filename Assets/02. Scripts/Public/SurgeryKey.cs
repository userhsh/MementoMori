using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SurgeryKey : Key
{
    private void Awake()
    {
        SurgeryKeyInit();    
    }

    // SurgeryKey Init 메서드
    private void SurgeryKeyInit()
    {
        // 현재 키를 SurgeryKey로 설정
        currentKey = KEY.SurgeryKey;
    }
}