using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlidePuzzleTile : MonoBehaviour
{
    // 각각의 타일 구분을 위한 int 변수 설정
    private int tileValue = 0;
    // tileValue 프로퍼티
    public int TileValue { get { return tileValue; } set { tileValue = value; } }

    // 타일의 최초(정답) 위치 가져올 변수 선언
    public Vector3 correctPosition = Vector3.zero;

    // 타일이 원래 위치로 돌아왔는지 확인할 변수 선언
    public bool IsCorrect { get; set; }
}