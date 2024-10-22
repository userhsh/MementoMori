using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mirror : MonoBehaviour, IInteractable
{
    // 거울 때 가져올 변수 선언
    MirrorStain mirrorStain = null;
    // 거울 때 제거하는 애니메이터 가져올 변수 선언
    Animator stainAnimator = null;
    // 거울 UI 가져올 변수 선언
    Canvas mirrorCanvas = null;

    bool isInteractable = false;

    public MedicineFabric medicineFabric = null;

    private void Awake()
    {
        MirrorInit();
    }

    // Mirror Init 메서드
    private void MirrorInit()
    {
        mirrorCanvas = GetComponentInChildren<Canvas>();
        mirrorStain = GetComponentInChildren<MirrorStain>();
        stainAnimator = mirrorStain.gameObject.GetComponent<Animator>();

        mirrorCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PillowFabic_Medicine")
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PillowFabic_Medicine")
        {
            isInteractable = false;
        }
    }

    public void Interact()
    {
        if (!isInteractable) return;

        // 거울 때 제거 코루틴 실행
        StartCoroutine(RemoveStain());
    }

    IEnumerator RemoveStain()
    {
        // 때 제거 애니메이션 실행
        stainAnimator.SetTrigger("IsRemoveStain");
        // 약 묻은 천 제거
        Destroy(medicineFabric);
        // 애니메이션 재생 시간 보장
        yield return new WaitForSeconds(1f);
        // 거울 캔버스 켜기
        mirrorCanvas.gameObject.SetActive(true);
    }
}