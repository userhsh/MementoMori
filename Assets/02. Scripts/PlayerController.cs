using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager; // GameManager를 참조하는 변수

    void Awake()
    {
        // 씬에서 GameManager를 찾고 gameManager 변수에 할당
        gameManager = FindObjectOfType<GameManager>();

        // 만약 GameManager가 씬에 존재하지 않는다면, 경고 로그를 출력하고 더 이상 진행하지 않음
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
        }
        else
        {
            Debug.Log("Loaded data is null or player position is not set. Setting player to default position.");
        }
    }
}
