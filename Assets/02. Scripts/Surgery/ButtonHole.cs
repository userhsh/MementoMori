using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHole : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Resources 폴더에서 메인 셔터 버튼 프리팹 가져오기
        GameObject mainShutterButton = Resources.Load("Prefabs/MainShutterButton") as GameObject;

        // 메인 셔터 버튼 생성
        Instantiate(mainShutterButton, this.transform.position, this.transform.rotation);

        // 버튼 홀 제거
        Destroy(gameObject);
    }
}