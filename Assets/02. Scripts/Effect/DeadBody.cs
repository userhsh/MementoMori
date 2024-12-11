using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;

public class DeadBody : MonoBehaviour
{
    int hoverCount = 0;

    Vector3 originPosition;

    AudioSource audioSource;
    [SerializeField]
    AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        audioSource.PlayOneShot(clip);
        while (shakeTime < 1f)
        {
            
            this.transform.localPosition = Random.insideUnitSphere * 0.2f + originPosition;
            shakeTime += Time.deltaTime;
            yield return null;
        }

        this.transform.localPosition = originPosition;
    }
}