using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlidePuzzleTile : MonoBehaviour
{
    // ������ Ÿ�� ������ ���� int ���� ����
    private int tileValue = 0;
    // tileValue ������Ƽ
    public int TileValue { get { return tileValue; } set { tileValue = value; } }

    // Ÿ���� ����(����) ��ġ ������ ���� ����
    public Vector3 correctPosition = Vector3.zero;

    // Ÿ���� ���� ��ġ�� ���ƿԴ��� Ȯ���� ���� ����
    public bool IsCorrect { get; set; }
}