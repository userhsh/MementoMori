using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;

public class DeadBody : MonoBehaviour
{
    int hoverCount = 0;

    Vector3 originPosition;

    public void Interact()
    {
        if (hoverCount != 0) return;

        hoverCount++;
        StartCoroutine(ShakeDeadBody());
    }

    IEnumerator ShakeDeadBody()
    { 
        float shakeTime = 0;
        originPosition = this.transform.localPosition;

        while (shakeTime < 1f)
        {
            this.transform.localPosition = Random.insideUnitSphere * 0.1f + originPosition;

            shakeTime += Time.deltaTime;
            yield return null;
        }

        this.transform.localPosition = originPosition;
    }
}