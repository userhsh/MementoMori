using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    // 셔터 조각들 담을 변수 선언
    ShutterPrice[] shutterPrices = null;

    private void Awake()
    {
        shutterPrices = GetComponentsInChildren<ShutterPrice>();
    }

    // 셔터 제거하는 메서드(외부 호출용)
    public void DestroyShutter()
    {
        StartCoroutine(DestroyShutterCo());
    }

    // 셔터 제거하는 코루틴
    IEnumerator DestroyShutterCo()
    {
        // 모든 셔터 조각에 대해 제일 아래 셔터 부터
        for (int i = 0; i < shutterPrices.Length; i++)
        {
            // 셔터 조각 사라지게 하기
            Destroy(shutterPrices[i]);
            // 0.1초 대기
            yield return new WaitForSeconds(0.1f);
        }
    }
}