using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogCollision : MonoBehaviour, IEffectable
{
    int collisionCount = 0;

    public UITalk uiTalk;

    Collider fogCollider = null;

    private void Awake()
    {
        fogCollider = GetComponent<Collider>();
    }

    public void TriggerEffect()
    {
        if (collisionCount != 0) return;

        StartCoroutine(uiTalk.InteractionTalk("����� ���� �ȵ� �� ����..."));
        collisionCount++;

        StartCoroutine(OffFogCollider());
    }

    IEnumerator OffFogCollider()
    {
        yield return new WaitForSeconds(1.5f);
        
        fogCollider.isTrigger = true;
    }
}