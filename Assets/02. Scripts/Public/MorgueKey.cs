using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueKey : Key
{
    private void Awake()
    {
        MorgueKeyInit();
    }

    // MorgueKey Init 메서드
    private void MorgueKeyInit()
    {
        // 현재 키를 MorgueKey로 설정
        currentKey = KEY.MorgueKey;
    }
}