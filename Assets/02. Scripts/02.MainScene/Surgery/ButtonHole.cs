using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHole : MonoBehaviour, IInteractable
{
    // 상호작용 가능한지 확인할 bool값 선언
    bool isInteractable = false;

    public SurgeryShutterButton surgeryShutterButton;

    public ShutterButton shutterButton;

    private void Awake()
    {
        surgeryShutterButton.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 만약 충돌한 물체가 셔터 버튼이면
        if (collision.collider.gameObject.name == "ShutterButton")
        {
            // 상호작용 가능
            isInteractable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 만약 셔터 버튼과 충돌이 끝났다면
        if (collision.collider.gameObject.name == "ShutterButton")
        {
            // 상호작용 불가능
            isInteractable = false;
        }
    }
        
    public void Interact()
    {
        // 상호작용 가능한 상태가 아닐때 돌아가기
        if (!isInteractable) return;

        surgeryShutterButton.gameObject.SetActive(true);

        Destroy(shutterButton.gameObject);
        // 버튼 홀 제거
        Destroy(this.gameObject);
    }
}