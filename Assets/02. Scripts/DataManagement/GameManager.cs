using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // 싱글톤 인스턴스
    private string saveFilePath;

    void Awake()
    {
        // 이미 인스턴스가 있다면 자신을 파괴
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // 인스턴스 설정
        DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
    }

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    public void StartNewGame()
    {
        // 초기 위치를 설정
        Vector3 initialPosition = new Vector3(8.65f, 0.759f, -6.64f); // 시작 위치를 설정 (필요에 따라 수정)

        // 새 게임 데이터를 초기화
        GameData gameData = new GameData { playerPosition = initialPosition };

        // JSON으로 저장
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("새 게임이 시작되었습니다.");
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
        return new GameData { playerPosition = Vector3.zero }; // 기본값으로 (0, 0, 0) 반환
    }

    private void OnApplicationQuit()
    {
        // 애플리케이션이 종료될 때 플레이어 데이터를 저장
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            SaveGameData(playerController.transform.position);
        }
    }

    public static GameManager GetInstance() // 인스턴스 접근을 위한 정적 메서드
    {
        return instance;
    }
}