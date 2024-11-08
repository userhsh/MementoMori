using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffect : MonoBehaviour, IEffectable
{
    public GameObject triggerObject;

    Material[] objectMaterials = null;

    private void Awake()
    {
        objectMaterials = triggerObject.GetComponent<Renderer>().materials;
    }

    public void TriggerEffect()
    {
        foreach (Material mat in objectMaterials) 
        {
            if (mat == null)
            {
                return;
            }
        }

        StartChangeMaterial();
    }

    private void StartChangeMaterial()
    {
        StartCoroutine(ChangeMaterial());
    }

    IEnumerator ChangeMaterial()
    {
        triggerObject.GetComponent<Renderer>().material = objectMaterials[1];

        yield return new WaitForSeconds(1.5f);

        triggerObject.GetComponent<Renderer>().material = objectMaterials[0];
    }
}