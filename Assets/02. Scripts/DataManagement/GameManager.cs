using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private string saveFilePath;
    public bool isContinueAvailable;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");
        Debug.Log("Persistent data path: " + Application.persistentDataPath);

        GameData loadedData = LoadGameData();

        if (loadedData != null) // 데이터가 존재하면
        {
            isContinueAvailable = loadedData.isContinueAvailable; // 저장된 이어하기 가능 여부 불러오기
            Debug.Log("Loaded isContinueAvailable: " + loadedData.isContinueAvailable);

            // MainmenuButtons의 UpdateContinueButton 호출
            MainmenuButtons mainmenuButtons = FindObjectOfType<MainmenuButtons>();
            if (mainmenuButtons != null)
            {
                mainmenuButtons.UpdateContinueButton(isContinueAvailable);
            }

        }
        else
        {
            isContinueAvailable = false; // 저장된 데이터가 없으면 이어하기 불가능
        }
    }

    public void StartNewGame()
    {
        Vector3 initialPosition = new Vector3(8.65f, 0.759f, -6.64f);
        GameData gameData = new GameData { playerPosition = initialPosition, isContinueAvailable = true };
        SaveGameData(gameData);

        isContinueAvailable = true;
        Debug.Log("새 게임이 시작되었습니다.");
    }

    public void SaveGameData(Vector3 playerPosition)
    {
        GameData gameData = new GameData
        {
            playerPosition = playerPosition,
            isContinueAvailable = this.isContinueAvailable // 이어하기 가능 상태도 저장
        };
        SaveGameData(gameData);
    }

    private void SaveGameData(GameData gameData)
    {
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
        return null;
    }

    private void OnApplicationQuit()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            SaveGameData(playerController.transform.position);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
}