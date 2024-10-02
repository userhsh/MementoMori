using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour, IInteractable
{
    // 거울 때 가져올 변수 선언
    MirrorStain mirrorStain = null;
    // 거울 때 제거하는 애니메이터 가져올 변수 선언
    Animator stainAnimator = null;

    private void Awake()
    {
        MirrorInit();
    }

    // Mirror Init 메서드
    private void MirrorInit()
    {
        mirrorStain = GetComponentInChildren<MirrorStain>();
        stainAnimator = mirrorStain.gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        // 거울 때 제거 코루틴 실행
        StartCoroutine(RemoveStain());
    }

    IEnumerator RemoveStain()
    {
        // 때 제거 애니메이션 실행
        stainAnimator.SetTrigger("IsRemoveStain");
        // 애니메이션 재생 시간 보장
        yield return new WaitForSeconds(1f);
        // 때 제거
        Destroy(mirrorStain.gameObject);
    }
}