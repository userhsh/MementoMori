using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // GameData�� �ε��Ͽ� �÷��̾��� ��ġ�� ����
        GameData loadedData = gameManager.LoadGameData();
        transform.position = loadedData.playerPosition; // �÷��̾ �ε��� ��ġ�� �̵�
    }
}