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

        if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
        {
            StartCoroutine(uiTalk.InteractionTalk("I don't think I should go.."));
        }
        else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
        {
           StartCoroutine(uiTalk.InteractionTalk("여기로 가면 안될 것 같다..."));
        }
        
        collisionCount++;

        StartCoroutine(OffFogCollider());
    }

    IEnumerator OffFogCollider()
    {
        yield return new WaitForSeconds(1.5f);
        
        fogCollider.isTrigger = true;
    }
}