using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    private bool isTap = false; // 수도꼭지 존재 여부 판별 변수

    public void Interact()
    {
        if (isTap) // 수도꼭지가 세면대에 존재한다면
        {
            // 물 틀기
            print("Water");
        }
        else // 수도꼭지가 없다면
        {
            // 물을 틀지 않음
            print("No Tap");
        }
    }
}