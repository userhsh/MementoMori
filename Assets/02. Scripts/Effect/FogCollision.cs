using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogCollision : MonoBehaviour, IEffectable
{
    public UITalk uiTalk;

    public void TriggerEffect()
    {
        StartCoroutine(uiTalk.InteractionTalk("아직 갈 수 없을 것 같다..."));
    }
}