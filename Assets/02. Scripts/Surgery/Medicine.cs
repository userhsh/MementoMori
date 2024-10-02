using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Resources 폴더에서 약 묻은 천 프리팹 가져오기
        GameObject medicineFabic = Resources.Load("Prefabs/PillowFabic_Medicine") as GameObject;

        // 천 생성
        Instantiate(medicineFabic, this.transform.position + new Vector3(0, 0.1f, 0), medicineFabic.transform.rotation);

        // 약품 제거
        Destroy(gameObject);
    }
}