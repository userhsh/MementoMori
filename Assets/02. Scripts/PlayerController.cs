using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager; // GameManager를 참조하는 변수

    // 카메라 오프셋 담을 변수
    private CameraOffset cameraOffset;

    // 인터페이스 담을 변수
    private IEffectable effectable;
    private IShakable shakable;

    // 카메라 기본 위치 담을 변수
    Vector3 cameraOffsetOriginPosition;

    int shakeCount = 0;

    void Awake()
    {
        // 씬에서 GameManager를 찾고 gameManager 변수에 할당
        gameManager = FindObjectOfType<GameManager>();
        // 카메라 오프셋 가져오기
        cameraOffset = GetComponentInChildren<CameraOffset>();

        // 만약 GameManager가 씬에 존재하지 않는다면, 로그를 출력하고 더 이상 진행하지 않음
        if (gameManager == null)
        {
            Debug.Log("GameManager not found in the scene!"); // 로그 추가
            return; // GameManager가 없을 경우 메서드 종료
        }

        // GameManager에서 저장된 GameData를 불러옴
        GameData loadedData = gameManager.LoadGameData();

        // 불러온 데이터가 존재할 경우, 플레이어의 위치를 해당 데이터의 위치로 설정
        if (loadedData != null && loadedData.playerPosition != null) // playerPosition도 null인지 체크
        {
            transform.position = loadedData.playerPosition; // 플레이어를 로드한 위치로 이동
            transform.rotation = Quaternion.Euler(loadedData.playerRotation); // 플레이어의 회전을 로드한 회전값으로 설정
        }
        else
        {
            //Debug.Log("Loaded data is null or player position is not set. Setting player to default position.");
            // 필요 시 기본값으로 설정
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 인터페이스 가져오기
        effectable = other.GetComponent<IEffectable>();
        shakable = other.GetComponent<IShakable>();

        // 트리거 이펙트 실행
        effectable?.TriggerEffect();

        // 쉐이크 가능 확인
        if (shakable != null)
        {
            if (shakeCount > 2) return;

            StartShakeCamera();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        effectable = collision.collider.gameObject.GetComponent<IEffectable>();

        effectable?.TriggerEffect();
    }

    private void StartShakeCamera()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        // 쉐이크 할 수 없으면 코루틴 탈출
        if (shakable == null) yield break;

        // 쉐이크 시간 
        float shakeTime = 0;
        // 카메라 기존 위치 가져오기
        cameraOffsetOriginPosition = cameraOffset.transform.localPosition;

        // 0.5초동안
        while (shakeTime < 1f)
        {
            // 카메라 cameraOffsetOriginPosition 위치에서 0.1 크기의 원으로 랜덤하게 흔들기
            cameraOffset.transform.localPosition = Random.insideUnitSphere * 0.1f + cameraOffsetOriginPosition;

            shakeTime += Time.deltaTime;
            yield return null;
        }

        // 카메라 위치 원래대로 돌리기
        cameraOffset.transform.localPosition = cameraOffsetOriginPosition;
        shakeCount++;
    }
}