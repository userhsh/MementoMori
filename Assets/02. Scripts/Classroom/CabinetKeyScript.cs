using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CabinetKeyScript : MonoBehaviour
{
    private Animator animator;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Animator 컴포넌트와 XRGrabInteractable 컴포넌트를 가져옴
        animator = GetComponentInParent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // 물체를 잡을 때 호출되는 이벤트 연결
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    // 물체가 잡혔을 때 호출되는 함수
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (animator != null)
        {
            animator.enabled = false;  // Animator 비활성화
            Debug.Log("오브젝트가 그랩되었습니다. 애니메이션을 비활성화합니다.");
        }
    }
}
