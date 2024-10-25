using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public bool isContinueAvailable; // �̾��ϱ� ���� ���θ� ����
    // �ٸ� �����͵� �ʿ��ϸ� �߰�
}

[System.Serializable]
public class VolumeData
{
    public float bgmVolume;
    public float masterVolume;
    public float sfxVolume;
}