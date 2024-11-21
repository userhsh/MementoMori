using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    private Light spotLight; // 스포트라이트 Light 컴포넌트를 저장하는 변수
    private float blinkInterval = 0.5f; // 스포트라이트 깜빡임 간격을 설정 (0.5초 간격)
    private Coroutine blinkCoroutine; // 깜빡임 코루틴을 제어하기 위한 변수

    private void Awake()
    {
        // 스포트라이트 Light 컴포넌트를 가져와서 초기화
        spotLight = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 충돌한 객체가 "Body" 태그를 가진 경우
        if (other.CompareTag("Body"))
        {
            // 깜빡임 코루틴 시작
            blinkCoroutine = StartCoroutine(BlinkLight());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 트리거에서 객체가 나갈 때 "Body" 태그를 가진 경우
        if (other.CompareTag("Body"))
        {
            // 깜빡임 코루틴 중지
            StopCoroutine(blinkCoroutine);
        }
    }

    // 스포트라이트를 깜빡이게 하는 코루틴
    private IEnumerator BlinkLight()
    {
        while (true)
        {
            // 스포트라이트의 활성 상태를 반전 (켜짐 <-> 꺼짐)
            spotLight.enabled = !spotLight.enabled;

            // 설정된 깜빡임 간격만큼 대기
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
