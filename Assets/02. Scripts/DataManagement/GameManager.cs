using System.IO;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    private static GameManager instance; // 싱글톤 인스턴스를 보관하는 변수
    private string saveFilePath; // 데이터 저장 파일 경로
    public bool isContinueAvailable; // 이어하기 가능 여부를 나타내는 변수

    void Awake()
    {
        // 싱글톤 패턴을 통해 GameManager 인스턴스를 하나만 유지
        if (instance != null) // 인스턴스가 이미 존재하면
        {
            Destroy(gameObject); // 새로운 인스턴스를 파괴
            return;
        }
        instance = this; // 인스턴스를 설정
        DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
    }

    void Start()
    {
        // 데이터 파일 경로 설정 (파일은 앱의 지속성 데이터 경로에 저장됨)
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // 게임 데이터 로드 시도
        GameData loadedData = LoadGameData();

        if (loadedData != null) // 저장된 데이터가 있으면
        {
            isContinueAvailable = loadedData.isContinueAvailable; // 저장된 이어하기 가능 여부 설정

            // MainmenuButtons 스크립트를 찾아서 이어하기 버튼 상태 업데이트
            MainmenuButtons mainmenuButtons = FindObjectOfType<MainmenuButtons>();
            if (mainmenuButtons != null)
            {
                mainmenuButtons.UpdateContinueButton(isContinueAvailable); // 이어하기 버튼 업데이트
            }
        }
        else
        {
            isContinueAvailable = false; // 데이터가 없으면 이어하기 불가능
        }
    }

    // 새로운 게임 시작 시 초기화 데이터 저장
    public void StartNewGame()
    {
        Vector3 initialPosition = new Vector3(8.75f, 0.36f, -5.96f); // 초기 플레이어 위치 설정
        Vector3 initialRotation = new Vector3(0, 183f, 0); // Y 로테이션을 180도로 설정

        GameData gameData = new GameData
        {
            playerPosition = initialPosition, // 초기 플레이어 위치
            playerRotation = initialRotation, // 초기 플레이어 회전 (Y: 180도)
            isContinueAvailable = true // 이어하기 가능 상태
        }; // 새 게임 데이터 설정

        SaveGameData(initialPosition, initialRotation); // 데이터 저장

        isContinueAvailable = true; // 이어하기 가능 상태로 변경
    }

    // 게임 데이터를 저장하는 메서드 (플레이어 위치 및 회전값을 인자로 받아 저장)
    public void SaveGameData(Vector3 playerPosition, Vector3 playerRotation)
    {
        GameData gameData = new GameData
        {
            playerPosition = playerPosition, // 현재 플레이어 위치 저장
            playerRotation = playerRotation, // 현재 플레이어 회전 저장
            isContinueAvailable = this.isContinueAvailable, // 현재 이어하기 가능 상태 저장
            doorLockStates = new List<bool>(),
            doorOpenStates = new List<bool>(),
            tapOnState = false // 기본값 설정
        };

        // 씬의 모든 DoorScript 컴포넌트를 찾아서 상태 저장
        DoorScript[] doors = FindObjectsOfType<DoorScript>();
        foreach (DoorScript door in doors)
        {
            gameData.doorLockStates.Add(door.isLocked);  // 잠금 상태 저장
            gameData.doorOpenStates.Add(door.isOpen);     // 열림 상태 저장
        }

        // 씬의 TapScript 컴포넌트를 찾아서 상태 저장
        TapScript tap = FindObjectOfType<TapScript>();
        if (tap != null)
        {
            gameData.tapOnState = tap.isTurnOn; // isTurnOn 상태 저장
        }

        // JSON 변환 후 파일에 쓰기
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, json);
    }

    // 게임 데이터를 파일에서 로드하는 메서드
    public GameData LoadGameData() // 반환값을 GameData 타입으로 지정하여 불러온 데이터를 리턴
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(json);

            // 문 상태 복원
            DoorScript[] doors = FindObjectsOfType<DoorScript>();
            for (int i = 0; i < doors.Length; i++)
            {
                if (i < loadedData.doorLockStates.Count && i < loadedData.doorOpenStates.Count)
                {
                    doors[i].isLocked = loadedData.doorLockStates[i]; // 잠금 상태 복원
                    doors[i].isOpen = loadedData.doorOpenStates[i];   // 열림 상태 복원
                    doors[i].UpdateDoorState();  // 문 상태 업데이트
                }
            }

            // TapScript 상태 복원
            TapScript tap = FindObjectOfType<TapScript>();
            if (tap != null) // TapScript가 존재하는 경우
            {
                tap.isTurnOn = loadedData.tapOnState; // 단일 변수로 상태 복원
                if (tap.isTurnOn)
                {
                    tap.TurnOnWater(null); // 상태가 켜져 있으면 물을 틉니다.
                }
            }

            return loadedData; // 로드된 GameData 객체 반환
        }
        return null; // 파일이 없거나 로드에 실패했을 경우 null 반환
    }

    // 게임 종료 시 호출되는 메서드로 현재 플레이어 위치와 회전값을 저장
    private void OnApplicationQuit()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>(); // 현재 씬에서 플레이어 객체를 찾음
        if (playerController != null)
        {
            SaveGameData(playerController.transform.position, playerController.transform.rotation.eulerAngles); // 플레이어 위치와 회전 저장
        }
        else
        {
            Debug.Log("PlayerController not found during application quit."); // 로그 추가
        }
    }

    // 싱글톤 인스턴스를 반환하는 메서드
    public static GameManager GetInstance()
    {
        return instance;
    }
}