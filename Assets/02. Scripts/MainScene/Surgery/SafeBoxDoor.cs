using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SafeBoxDoor : MonoBehaviour
{
    Animator safeDoorAnimator;
    public Animator SafeDoorAnimator {  get { return safeDoorAnimator; } }

    // �ݰ� �� init �޼���
    public void SafeDoorInit()
    {
        safeDoorAnimator = GetComponent<Animator>();
    }
}