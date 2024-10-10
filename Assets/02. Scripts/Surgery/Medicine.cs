using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour, IInteractable
{
    public MedicineFabric medicineFabric;

    private void Awake()
    {
        medicineFabric.gameObject.SetActive(false);
    }

    public void Interact()
    {
        // 약 묻은 천 생성
        medicineFabric.gameObject.SetActive(true);
        // 천 제거
        Destroy(medicineFabric.gameObject);
        // 약품 제거
        Destroy(gameObject);
    }
}