using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHole : MonoBehaviour, IInteractable
{
    // 상호작용 가능한지 확인할 bool값 선언
    bool isInteractable = false;

    // 트리거 발동 시
    private void OnTriggerEnter(Collider other)
    {
        // 만약 충돌한 물체가 셔터 버튼이면
        if (other.gameObject.name == "ShutterButton")
        {
            // 상호작용 가능
            isInteractable = true;
        }
    }

    // 트리거가 끝났을 시
    private void OnTriggerExit(Collider other)
    {
        // 만약 셔터 버튼과 충돌이 끝났다면
        if (other.gameObject.name == "ShutterButton")
        {
            // 상호작용 불가능
            isInteractable = false;
        }
    }

    public void Interact()
    {
        // 상호작용 가능한 상태가 아닐때 돌아가기
        if (!isInteractable) return;

        // Resources 폴더에서 메인 셔터 버튼 프리팹 가져오기
        GameObject mainShutterButton = Resources.Load("Prefabs/MainShutterButton") as GameObject;

        // 메인 셔터 버튼 생성
        Instantiate(mainShutterButton, this.transform.position, this.transform.rotation);

        // 버튼 홀 제거
        Destroy(gameObject);
    }
}