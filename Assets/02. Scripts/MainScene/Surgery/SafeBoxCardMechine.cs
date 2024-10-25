using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBoxCardMechine : MonoBehaviour
{
    // 렌더러 담을 변수 선언
    MeshRenderer cardMechineRenderer = null;

    // 카드 리더기 Init 메서드
    public void CardMechineInit()
    {
        cardMechineRenderer = GetComponent<MeshRenderer>();
    }

    // 카드 리더기 색깔 변화 메서드
    public void ChangeColor()
    {
        cardMechineRenderer.material.SetColor("_EmissionColor", Color.green);
    }
}