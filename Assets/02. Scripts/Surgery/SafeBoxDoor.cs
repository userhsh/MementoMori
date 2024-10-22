using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SafeBoxDoor : MonoBehaviour
{
    Animator safeDoorAnimator;
    public Animator SafeDoorAnimator {  get { return safeDoorAnimator; } }

    // 금고 문 init 메서드
    public void SafeDoorInit()
    {
        safeDoorAnimator = GetComponent<Animator>();
    }
}