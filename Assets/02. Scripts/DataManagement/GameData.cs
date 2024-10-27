using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition; // �÷��̾��� ���� ��ġ�� �����ϴ� ����
    public Vector3 playerRotation; // �÷��̾��� ���� ȸ������ �����ϴ� ����
    public bool isContinueAvailable; // �̾��ϱ� ���� ���θ� �����ϴ� ����
    public List<bool> doorLockStates; // �� ��� ���� ����Ʈ
    public List<bool> doorOpenStates; // �� ���� ���� ����Ʈ
}

[System.Serializable]
public class VolumeData
{
    public float bgmVolume; // ��� ���� ���� ������ �����ϴ� ����
    public float masterVolume; // ��ü ������ ���� ������ �����ϴ� ����
    public float sfxVolume; // ȿ����(SFX) ���� ������ �����ϴ� ����
}