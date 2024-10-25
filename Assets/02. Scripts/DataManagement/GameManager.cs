using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // �̱��� �ν��Ͻ�
    private string saveFilePath;

    void Awake()
    {
        // �̹� �ν��Ͻ��� �ִٸ� �ڽ��� �ı�
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // �ν��Ͻ� ����
        DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
    }

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    public void StartNewGame()
    {
        // �ʱ� ��ġ�� ����
        Vector3 initialPosition = new Vector3(8.65f, 0.759f, -6.64f); // ���� ��ġ�� ���� (�ʿ信 ���� ����)

        // �� ���� �����͸� �ʱ�ȭ
        GameData gameData = new GameData { playerPosition = initialPosition };

        // JSON���� ����
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("�� ������ ���۵Ǿ����ϴ�.");
    }

    public void SaveGameData(Vector3 playerPosition)
    {
        GameData gameData = new GameData { playerPosition = playerPosition };
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, json);
    }

    public GameData LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        return new GameData { playerPosition = Vector3.zero }; // �⺻������ (0, 0, 0) ��ȯ
    }

    private void OnApplicationQuit()
    {
        // ���ø����̼��� ����� �� �÷��̾� �����͸� ����
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            SaveGameData(playerController.transform.position);
        }
    }

    public static GameManager GetInstance() // �ν��Ͻ� ������ ���� ���� �޼���
    {
        return instance;
    }
}