using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour
{
    // SlidePuzzleBoard담을 변수 선언
    SlidePuzzleBoard board = null;
    // SlidePuzzleBoard 프로퍼티 get만 열어주기
    public SlidePuzzleBoard Board { get { return board; } }

    public void BoardInit()
    {
        board = GetComponentInChildren<SlidePuzzleBoard>();
    }
}