using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour
{
    // SlidePuzzleBoard���� ���� ����
    SlidePuzzleBoard board = null;
    // SlidePuzzleBoard ������Ƽ get�� �����ֱ�
    public SlidePuzzleBoard Board { get { return board; } }

    public void BoardInit()
    {
        board = GetComponentInChildren<SlidePuzzleBoard>();
    }
}