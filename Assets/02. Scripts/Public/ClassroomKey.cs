using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomKey : Key
{
    private void Awake()
    {
        ClassroomKeyInit();
    }

    // ClassroomKey Init 메서드
    private void ClassroomKeyInit()
    {
        // 현재 키를 ClassroomKey로 설정
        currentKey = KEY.ClassroomKey;
    }
}