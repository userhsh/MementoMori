using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayBox : MonoBehaviour
{
    Animator hallwayBoxAnimator = null;
    public Animator HallwayBoxAnimator { get { return hallwayBoxAnimator; } }

    public void HallwayBoxinit()
    {
        hallwayBoxAnimator = GetComponentInChildren<Animator>();
    }
}