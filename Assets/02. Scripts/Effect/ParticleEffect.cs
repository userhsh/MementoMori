using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour, IEffectable
{
    [SerializeField]
    private GameObject particle = null;

    int triggerCount = 0;

    private void Awake()
    {
        particle.SetActive(false);
    }

    public void TriggerEffect()
    {
        if (triggerCount % 4 == 0) 
        {
            particle.gameObject.SetActive(true);

            Invoke("EffectOff", 2f);
        }

        triggerCount++;
    }

    private void EffectOff()
    {
        particle?.SetActive(false);
    }
}