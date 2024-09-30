using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeKey : Key
{
    private void Awake()
    {
        OfficeKeyInit();
    }

    // OfficeKey Init 메서드
    private void OfficeKeyInit()
    {
        // 현재 키를 OfficeKey로 설정
        currentKey = KEY.OfficeKey;
    }
}