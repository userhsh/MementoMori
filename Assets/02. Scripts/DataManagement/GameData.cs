using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition; // 플레이어의 현재 위치를 저장하는 변수
    public Vector3 playerRotation; // 플레이어의 현재 회전값을 저장하는 변수
    public bool isContinueAvailable; // 이어하기 가능 여부를 저장하는 변수
    public List<bool> doorLockStates; // 문 잠금 상태 리스트
    public List<bool> doorOpenStates; // 문 열림 상태 리스트
}

[System.Serializable]
public class VolumeData
{
    public float bgmVolume; // 배경 음악 볼륨 레벨을 저장하는 변수
    public float masterVolume; // 전체 마스터 볼륨 레벨을 저장하는 변수
    public float sfxVolume; // 효과음(SFX) 볼륨 레벨을 저장하는 변수
}