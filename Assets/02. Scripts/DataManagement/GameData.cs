using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition; // 플레이어의 현재 위치를 저장하는 변수
    public bool isContinueAvailable; // 이어하기 가능 여부를 저장하는 변수
    // 필요 시 여기에 추가 데이터(예: 문 상태, 수집품, 플레이어 상태 등)를 추가하여 관리 가능
}

[System.Serializable]
public class VolumeData
{
    public float bgmVolume; // 배경 음악 볼륨 레벨을 저장하는 변수
    public float masterVolume; // 전체 마스터 볼륨 레벨을 저장하는 변수
    public float sfxVolume; // 효과음(SFX) 볼륨 레벨을 저장하는 변수
}