using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition; // �÷��̾��� ���� ��ġ�� �����ϴ� ����
    public bool isContinueAvailable; // �̾��ϱ� ���� ���θ� �����ϴ� ����
    // �ʿ� �� ���⿡ �߰� ������(��: �� ����, ����ǰ, �÷��̾� ���� ��)�� �߰��Ͽ� ���� ����
}

[System.Serializable]
public class VolumeData
{
    public float bgmVolume; // ��� ���� ���� ������ �����ϴ� ����
    public float masterVolume; // ��ü ������ ���� ������ �����ϴ� ����
    public float sfxVolume; // ȿ����(SFX) ���� ������ �����ϴ� ����
}