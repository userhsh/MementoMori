using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public bool isContinueAvailable; // 이어하기 가능 여부를 포함
    // 다른 데이터도 필요하면 추가
}

[System.Serializable]
public class VolumeData
{
    public float bgmVolume;
    public float masterVolume;
    public float sfxVolume;
}