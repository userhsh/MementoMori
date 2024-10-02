using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Resources 폴더에서 천 프리팹 가져오기
        GameObject fabic = Resources.Load("Prefabs/PillowFabic") as GameObject;

        // 천 생성
        Instantiate(fabic, this.transform.position, fabic.transform.rotation);

        // 베개 제거
        Destroy(gameObject);
    }
}