using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // GameData를 로드하여 플레이어의 위치를 설정
        GameData loadedData = gameManager.LoadGameData();
        transform.position = loadedData.playerPosition; // 플레이어를 로드한 위치로 이동
    }
}