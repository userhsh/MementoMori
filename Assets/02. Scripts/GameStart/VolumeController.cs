using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;   // 볼륨을 조절할 슬라이더
    public AudioSource audioSource;  // 오디오 소스

    private void Start()
    {
        // PlayerPrefs에서 저장된 볼륨 값을 불러와 적용
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;  // 슬라이더에 저장된 값 반영
            audioSource.volume = savedVolume;  // 오디오 소스에 저장된 값 반영
        }
        else
        {
            // 저장된 값이 없으면 기본 값 1로 설정
            volumeSlider.value = 1;
            audioSource.volume = 1;
        }

        // 슬라이더 값이 변경될 때 볼륨을 조절
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // 슬라이더 값을 기반으로 볼륨을 조절하는 함수
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;  // 오디오 볼륨을 슬라이더 값으로 설정
        PlayerPrefs.SetFloat("Volume", volume);  // 볼륨 값을 저장
        PlayerPrefs.Save();  // PlayerPrefs 저장
    }
}