using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager; // GameManager�� �����ϴ� ����

    void Awake()
    {
        // ������ GameManager�� ã�� gameManager ������ �Ҵ�
        gameManager = FindObjectOfType<GameManager>();

        // ���� GameManager�� ���� �������� �ʴ´ٸ�, ��� �α׸� ����ϰ� �� �̻� �������� ����
        if (gameManager == null)
        {
            Debug.Log("GameManager not found in the scene!"); // �α� �߰�
            return; // GameManager�� ���� ��� �޼��� ����
        }

        // GameManager���� ����� GameData�� �ҷ���
        GameData loadedData = gameManager.LoadGameData();

        // �ҷ��� �����Ͱ� ������ ���, �÷��̾��� ��ġ�� �ش� �������� ��ġ�� ����
        if (loadedData != null && loadedData.playerPosition != null) // playerPosition�� null���� üũ
        {
            transform.position = loadedData.playerPosition; // �÷��̾ �ε��� ��ġ�� �̵�
        }
        else
        {
            Debug.Log("Loaded data is null or player position is not set. Setting player to default position.");
        }
    }
}
