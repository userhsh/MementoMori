using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBoxCardMechine : MonoBehaviour
{
    // ������ ���� ���� ����
    MeshRenderer cardMechineRenderer = null;

    // ī�� ������ Init �޼���
    public void CardMechineInit()
    {
        cardMechineRenderer = GetComponent<MeshRenderer>();
    }

    // ī�� ������ ���� ��ȭ �޼���
    public void ChangeColor()
    {
        cardMechineRenderer.material.SetColor("_EmissionColor", Color.green);
    }
}