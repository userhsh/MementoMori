using System.IO;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Playables;
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤 인스턴스를 보관하는 변수
    public static GameManager Instance { get { return instance; } }
    public bool isTutorial { get; set; }

    private string saveFilePath; // 데이터 저장 파일 경로
    public bool isContinueAvailable; // 이어하기 가능 여부를 나타내는 변수
    public bool crowbarActive;

    public
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

        // 크로우바 초기화 및 활성화
        ItemCrowBar crowbar = FindObjectOfType<ItemCrowBar>();
        if (crowbar != null)
        {
            crowbar.gameObject.SetActive(true); // 크로우바를 활성화
            crowbar.use = false; // 크로우바의 사용 상태를 초기화
        }

        // 초기화 할 crowbarActive 값을 true로 설정
        crowbarActive = true; // 새로운 게임 시작 시 크로우바 활성화

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
            // 0.플레이어 위치,회전 및 이어하기 여부
            playerPosition = playerPosition, // 현재 플레이어 위치 저장
            playerRotation = playerRotation, // 현재 플레이어 회전 저장
            isContinueAvailable = this.isContinueAvailable, // 현재 이어하기 가능 상태 저장

            // 1. 시체안치실 
            morgueDoorOpenStates = new List<bool>(),
            morgueDoorLockStates = new List<bool>(),
            morgueBoxDoorOpenStates = new List<bool>(),
            medRackDoorLockStates = new List<bool>(),
            medRackDoorOpenStates = new List<bool>(),
            crowbarActive = this.crowbarActive,

            // 2. 교실
            classroomdoorLockStates = new List<bool>(),
            classroomdoorOpenStates = new List<bool>(),
            tapOnState = false, // 기본값 설정
        };

        // 씬의 MorgueDoor 컴포넌트를 찾아서 상태 저장
        MorgueDoor[] morgueDoors = FindObjectsOfType<MorgueDoor>();
        foreach (MorgueDoor door in morgueDoors)
        {
            gameData.morgueDoorOpenStates.Add(door.isOpen);
            gameData.morgueDoorLockStates.Add(door.isLocked);
        }

        // 씬의 모든 MorgueBoxDoor 컴포넌트를 찾아서 상태 저장
        MorgueBoxDoor[] morgueBoxDoors = FindObjectsOfType<MorgueBoxDoor>();
        foreach (MorgueBoxDoor door in morgueBoxDoors)
        {
            gameData.morgueBoxDoorOpenStates.Add(door.DoorOpen);
        }

        //씬의 모든 MedRackDoor 컴포넌트를 찾아서 상태 저장
        MedRackDoor[] MedRackDoors = FindObjectsOfType<MedRackDoor>();
        foreach (MedRackDoor door in MedRackDoors)
        {
            gameData.medRackDoorOpenStates.Add(door.DoorOpen); // 열림 상태 저장
            gameData.medRackDoorLockStates.Add(door.MedRackDoorLock); // 잠금 상태 저장
        }

        ItemCrowBar crowbar = FindObjectOfType<ItemCrowBar>();
        if (crowbar != null)
        {
            gameData.crowbarActive = crowbar.gameObject.activeSelf; // 활성화 상태 저장
        }

        // 씬의 모든 DoorScript 컴포넌트를 찾아서 상태 저장
        DoorScript[] classroomdoors = FindObjectsOfType<DoorScript>();
        foreach (DoorScript door in classroomdoors)
        {
            gameData.classroomdoorOpenStates.Add(door.isOpen);     // 열림 상태 저장
            gameData.classroomdoorLockStates.Add(door.isLocked);  // 잠금 상태 저장
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

            //시체안치실 MorgueDoor 상태 복원
            MorgueDoor[] morgueDoors = FindObjectsOfType<MorgueDoor>();
            for (int i = 0; i < morgueDoors.Length; i++)
            {
                if (i < loadedData.morgueDoorOpenStates.Count)
                {
                    morgueDoors[i].isOpen = loadedData.morgueDoorOpenStates[i];
                    morgueDoors[i].isLocked = loadedData.morgueDoorLockStates[i];
                    morgueDoors[i].UpdateMorgueDoorState();
                }
            }

            //시체안치실 MorgueBoxDoor 상태 복원
            MorgueBoxDoor[] morgueBoxDoors = FindObjectsOfType<MorgueBoxDoor>();
            for (int i = 0; i < morgueBoxDoors.Length; i++)
            {
                if (i < loadedData.morgueBoxDoorOpenStates.Count)
                {
                    morgueBoxDoors[i].DoorOpen = loadedData.morgueBoxDoorOpenStates[i]; // 열림 상태 복원
                    morgueBoxDoors[i].UpdateMorgueBoxDoorState();
                }
            }

            //시체안치실 MedRackDoor 상태 복원
            MedRackDoor[] medRackDoors = FindObjectsOfType<MedRackDoor>();
            for (int i = 0; i < medRackDoors.Length; i++)
            {
                if (i < loadedData.medRackDoorLockStates.Count && i < loadedData.medRackDoorOpenStates.Count)
                {
                    medRackDoors[i].DoorOpen = loadedData.medRackDoorOpenStates[i]; // 열림 상태 복원
                    medRackDoors[i].MedRackDoorLock = loadedData.medRackDoorLockStates[i]; // 잠금 상태 복원
                    medRackDoors[i].UpdateMedRackDoorState(); // 문 상태 업데이트
                }
            }

            // 크로우바 상태 복원
            ItemCrowBar crowbar = FindObjectOfType<ItemCrowBar>();
            if (crowbar != null)
            {
                crowbar.gameObject.SetActive(loadedData.crowbarActive); // 활성화 상태 복원
            }

            // 교실 문 상태 복원
            DoorScript[] classroomdoors = FindObjectsOfType<DoorScript>();
            for (int i = 0; i < classroomdoors.Length; i++)
            {
                if (i < loadedData.classroomdoorLockStates.Count && i < loadedData.classroomdoorOpenStates.Count)
                {
                    classroomdoors[i].isOpen = loadedData.classroomdoorOpenStates[i];   // 열림 상태 복원
                    classroomdoors[i].isLocked = loadedData.classroomdoorLockStates[i]; // 잠금 상태 복원
                    classroomdoors[i].UpdateClassroomDoorState();  // 문 상태 업데이트
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