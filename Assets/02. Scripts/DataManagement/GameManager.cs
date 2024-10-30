using System.IO;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    private static GameManager instance; // �̱��� �ν��Ͻ��� �����ϴ� ����
    private string saveFilePath; // ������ ���� ���� ���
    public bool isContinueAvailable; // �̾��ϱ� ���� ���θ� ��Ÿ���� ����

    void Awake()
    {
        // �̱��� ������ ���� GameManager �ν��Ͻ��� �ϳ��� ����
        if (instance != null) // �ν��Ͻ��� �̹� �����ϸ�
        {
            Destroy(gameObject); // ���ο� �ν��Ͻ��� �ı�
            return;
        }
        instance = this; // �ν��Ͻ��� ����
        DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
    }

    void Start()
    {
        // ������ ���� ��� ���� (������ ���� ���Ӽ� ������ ��ο� �����)
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // ���� ������ �ε� �õ�
        GameData loadedData = LoadGameData();

        if (loadedData != null) // ����� �����Ͱ� ������
        {
            isContinueAvailable = loadedData.isContinueAvailable; // ����� �̾��ϱ� ���� ���� ����

            // MainmenuButtons ��ũ��Ʈ�� ã�Ƽ� �̾��ϱ� ��ư ���� ������Ʈ
            MainmenuButtons mainmenuButtons = FindObjectOfType<MainmenuButtons>();
            if (mainmenuButtons != null)
            {
                mainmenuButtons.UpdateContinueButton(isContinueAvailable); // �̾��ϱ� ��ư ������Ʈ
            }
        }
        else
        {
            isContinueAvailable = false; // �����Ͱ� ������ �̾��ϱ� �Ұ���
        }
    }

    // ���ο� ���� ���� �� �ʱ�ȭ ������ ����
    public void StartNewGame()
    {
        Vector3 initialPosition = new Vector3(8.75f, 0.36f, -5.96f); // �ʱ� �÷��̾� ��ġ ����
        Vector3 initialRotation = new Vector3(0, 183f, 0); // Y �����̼��� 180���� ����

        GameData gameData = new GameData
        {
            playerPosition = initialPosition, // �ʱ� �÷��̾� ��ġ
            playerRotation = initialRotation, // �ʱ� �÷��̾� ȸ�� (Y: 180��)
            isContinueAvailable = true // �̾��ϱ� ���� ����
        }; // �� ���� ������ ����

        SaveGameData(initialPosition, initialRotation); // ������ ����

        isContinueAvailable = true; // �̾��ϱ� ���� ���·� ����
    }

    // ���� �����͸� �����ϴ� �޼��� (�÷��̾� ��ġ �� ȸ������ ���ڷ� �޾� ����)
    public void SaveGameData(Vector3 playerPosition, Vector3 playerRotation)
    {
        GameData gameData = new GameData
        {
            playerPosition = playerPosition, // ���� �÷��̾� ��ġ ����
            playerRotation = playerRotation, // ���� �÷��̾� ȸ�� ����
            isContinueAvailable = this.isContinueAvailable, // ���� �̾��ϱ� ���� ���� ����
            morgueBoxDoorOpenStates = new List<bool>(),
            medRackDoorLockStates = new List<bool>(),
            medRackDoorOpenStates = new List<bool>(),
            classroomdoorLockStates = new List<bool>(),
            classroomdoorOpenStates = new List<bool>(),
            tapOnState = false // �⺻�� ����
        };

        // ���� ��� MorgueBoxDoor ������Ʈ�� ã�Ƽ� ���� ����
        MorgueBoxDoor[] morgueBoxDoors = FindObjectsOfType<MorgueBoxDoor>();
        foreach (MorgueBoxDoor door in morgueBoxDoors)
        {
            gameData.morgueBoxDoorOpenStates.Add(door.DoorOpen);
        }

        //���� ��� MedRackDoor ������Ʈ�� ã�Ƽ� ���� ����
        MedRackDoor[] MedRackDoors = FindObjectsOfType<MedRackDoor>();
        foreach (MedRackDoor door in MedRackDoors)
        {
            gameData.medRackDoorLockStates.Add(door.MedRackDoorLock); // ��� ���� ����
            gameData.medRackDoorOpenStates.Add(door.DoorOpen); // ���� ���� ����
        }

        // ���� ��� DoorScript ������Ʈ�� ã�Ƽ� ���� ����
        DoorScript[] classroomdoors = FindObjectsOfType<DoorScript>();
        foreach (DoorScript door in classroomdoors)
        {
            gameData.classroomdoorLockStates.Add(door.isLocked);  // ��� ���� ����
            gameData.classroomdoorOpenStates.Add(door.isOpen);     // ���� ���� ����
        }

        // ���� TapScript ������Ʈ�� ã�Ƽ� ���� ����
        TapScript tap = FindObjectOfType<TapScript>();
        if (tap != null)
        {
            gameData.tapOnState = tap.isTurnOn; // isTurnOn ���� ����
        }

        // JSON ��ȯ �� ���Ͽ� ����
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, json);
    }

    // ���� �����͸� ���Ͽ��� �ε��ϴ� �޼���
    public GameData LoadGameData() // ��ȯ���� GameData Ÿ������ �����Ͽ� �ҷ��� �����͸� ����
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(json);

            //��ü��ġ�� MorgueBoxDoor ���� ����
            MorgueBoxDoor[] morgueBoxDoors = FindObjectsOfType<MorgueBoxDoor>();
            for (int i = 0; i < morgueBoxDoors.Length; i++)
            {
                if (i < loadedData.morgueBoxDoorOpenStates.Count)
                {
                    morgueBoxDoors[i].DoorOpen = loadedData.morgueBoxDoorOpenStates[i]; // ���� ���� ����
                    morgueBoxDoors[i].UpdateMorgueBoxDoorState();
                }
            }

            //��ü��ġ�� MedRackDoor ���� ����
            MedRackDoor[] medRackDoors = FindObjectsOfType<MedRackDoor>();
            for (int i = 0; i < medRackDoors.Length; i++)
            {
                if (i < loadedData.medRackDoorLockStates.Count && i < loadedData.medRackDoorOpenStates.Count)
                {
                    medRackDoors[i].MedRackDoorLock = loadedData.medRackDoorLockStates[i]; // ��� ���� ����
                    medRackDoors[i].DoorOpen = loadedData.medRackDoorOpenStates[i]; // ���� ���� ����
                    medRackDoors[i].UpdateMedRackDoorState(); // �� ���� ������Ʈ
                }
            }

            // ���� �� ���� ����
            DoorScript[] classroomdoors = FindObjectsOfType<DoorScript>();
            for (int i = 0; i < classroomdoors.Length; i++)
            {
                if (i < loadedData.classroomdoorLockStates.Count && i < loadedData.classroomdoorOpenStates.Count)
                {
                    classroomdoors[i].isLocked = loadedData.classroomdoorLockStates[i]; // ��� ���� ����
                    classroomdoors[i].isOpen = loadedData.classroomdoorOpenStates[i];   // ���� ���� ����
                    classroomdoors[i].UpdateClassroomDoorState();  // �� ���� ������Ʈ
                }
            }

            // TapScript ���� ����
            TapScript tap = FindObjectOfType<TapScript>();
            if (tap != null) // TapScript�� �����ϴ� ���
            {
                tap.isTurnOn = loadedData.tapOnState; // ���� ������ ���� ����
                if (tap.isTurnOn)
                {
                    tap.TurnOnWater(null); // ���°� ���� ������ ���� Ƶ�ϴ�.
                }
            }

            return loadedData; // �ε�� GameData ��ü ��ȯ
        }
        return null; // ������ ���ų� �ε忡 �������� ��� null ��ȯ
    }

    // ���� ���� �� ȣ��Ǵ� �޼���� ���� �÷��̾� ��ġ�� ȸ������ ����
    private void OnApplicationQuit()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>(); // ���� ������ �÷��̾� ��ü�� ã��
        if (playerController != null)
        {
            SaveGameData(playerController.transform.position, playerController.transform.rotation.eulerAngles); // �÷��̾� ��ġ�� ȸ�� ����
        }
        else
        {
            Debug.Log("PlayerController not found during application quit."); // �α� �߰�
        }
    }

    // �̱��� �ν��Ͻ��� ��ȯ�ϴ� �޼���
    public static GameManager GetInstance()
    {
        return instance;
    }
}