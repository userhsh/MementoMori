using UnityEngine;

public class ApplySavedVolume : MonoBehaviour
{
    public AudioSource audioSource;  // 씬 내의 오디오 소스

    private void Start()
    {
        // PlayerPrefs에서 저장된 볼륨 값을 불러와 오디오 소스에 적용
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioSource.volume = savedVolume;
        }
        else
        {
            // 저장된 값이 없으면 기본 볼륨을 1로 설정
            audioSource.volume = 1;
        }
    }
}