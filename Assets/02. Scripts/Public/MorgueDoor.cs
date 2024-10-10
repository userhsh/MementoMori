using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueDoor : Door
{
    private void Awake()
    {
        MorgueDoorInit();
    }

    // 시체 안치실 문 init 메서드
    private void MorgueDoorInit()
    {
        // 현재 로드된 씬 이름 가져오기
        GetCurrentSceneName();

        // 문을 잠긴 상태로 
        isLocked = false;

        // 이동할 씬 이름 가져오기
        if (currentSceneName == SCENENAME.HallwayScene.ToString()) // 현재 씬이 복도 씬이라면 
        {
            // 이동할 씬 이름에 시체 안치실 씬 이름 가져오기
            moveSceneName = SCENENAME.MorgueScene.ToString();
        }
        else // 현재 씬이 복도 씬이 아니라면
        {
            // 이동할 씬 이름에 복도 씬 이름 가져오기
            moveSceneName = SCENENAME.HallwayScene.ToString();
        }
    }
}