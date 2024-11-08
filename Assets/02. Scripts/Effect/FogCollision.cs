using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogCollision : MonoBehaviour, IEffectable
{
    public UITalk uiTalk;

    public void TriggerEffect()
    {
        StartCoroutine(uiTalk.InteractionTalk("���� �� �� ���� �� ����..."));
    }
}