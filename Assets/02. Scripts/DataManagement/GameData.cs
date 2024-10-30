using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    // 0.�÷��̾� ��ġ,ȸ�� �� �̾��ϱ� ���� ������
    public Vector3 playerPosition; // �÷��̾��� ���� ��ġ�� �����ϴ� ����
    public Vector3 playerRotation; // �÷��̾��� ���� ȸ������ �����ϴ� ����
    public bool isContinueAvailable; // �̾��ϱ� ���� ���θ� �����ϴ� ����

    // 1.��ü��ġ�� ������
    public List<bool> morgueDoorOpenStates; // ��ü��ġ�� �� ���� ���� ����Ʈ
    public List<bool> morgueDoorLockStates; // ��ü��ġ�� �� ��� ���� ����Ʈ
    public List<bool> morgueBoxDoorOpenStates; // ��ü��ġ�� �ڽ� �� ���� ���� ����Ʈ
    public List<bool> medRackDoorOpenStates; // ��ü��ġ�� MedRackDoor ���� ���� ����Ʈ
    public List<bool> medRackDoorLockStates; // ��ü��ġ�� MedRackDoor ��� ���� ����Ʈ
    public bool crowbarActive; // ũ�ο�� Ȱ��ȭ ���¸� �����ϴ� ���� �߰�

    // 2. ���� ������
    public List<bool> classroomdoorOpenStates; // ���� �� ���� ���� ����Ʈ
    public List<bool> classroomdoorLockStates; // ���� �� ��� ���� ����Ʈ
    public bool tapOnState; // TapScript�� ���¸� �����ϴ� ���� (true : ���� , false : ����)
}

[System.Serializable]
public class VolumeData
{
    public float bgmVolume; // ��� ���� ���� ������ �����ϴ� ����
    public float masterVolume; // ��ü ������ ���� ������ �����ϴ� ����
    public float sfxVolume; // ȿ����(SFX) ���� ������ �����ϴ� ����
}