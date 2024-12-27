using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;   // AudioMixer를 연결
    public Slider bgmVolumeSlider;  // 배경 음악 볼륨 슬라이더
    public Slider masterVolumeSlider; // 마스터 볼륨 슬라이더
    public Slider sfxVolumeSlider;  // 효과음(SFX) 슬라이더

    public AudioSource sfxAudioSource;

    private string saveFilePath;

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "volumeData.json");

        // 이전에 저장된 볼륨 데이터 로드
        LoadVolumeData();

        // 씬 전환 후 슬라이더와 오디오 믹서의 값 동기화
        SyncSlidersWithAudioMixer();

        // 슬라이더 값 변경 시 볼륨 조정
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void OnEnable()
    {
        // 씬 전환 후 슬라이더와 오디오 믹서 값 동기화 (활성화될 때)
        SyncSlidersWithAudioMixer();
    }

    // 오디오 믹서와 슬라이더 값을 동기화하는 함수
    void SyncSlidersWithAudioMixer()
    {
        float bgmVolume, masterVolume, sfxVolume;

        // 오디오 믹서의 현재 볼륨 값을 받아와 슬라이더에 반영
        audioMixer.GetFloat("BGM", out bgmVolume);
        audioMixer.GetFloat("Master", out masterVolume);
        audioMixer.GetFloat("SFX", out sfxVolume);

        // 슬라이더에 오디오 믹서 값을 변환해서 반영 (dB를 0~1 범위로 변환)
        bgmVolumeSlider.value = Mathf.Pow(10, bgmVolume / 20);
        masterVolumeSlider.value = Mathf.Pow(10, masterVolume / 20);
        sfxVolumeSlider.value = Mathf.Pow(10, sfxVolume / 20);
    }

    // 슬라이더 값이 변경될 때 호출될 함수
    public void SetBGMVolume(float sliderValue)
    {
        // 슬라이더 값이 0일 경우 음소거 상태로 설정
        if (sliderValue <= 0.0001f) // 0에 너무 가까운 값을 방지하기 위해 작은 값을 설정
        {
            audioMixer.SetFloat("BGM", -80f);   // 최소 볼륨 (-80dB로 설정)
        }
        else
        {
            float masterVolume;
            audioMixer.GetFloat("Master", out masterVolume);
            // 마스터 볼륨에 비례하여 배경 음악 볼륨 조정
            float volume = Mathf.Log10(sliderValue) * 20 + masterVolume;
            audioMixer.SetFloat("BGM", volume);
        }
        SaveVolumeData(); // 볼륨 데이터 저장
    }

    public void SetMasterVolume(float sliderValue)
    {
        if (sliderValue <= 0.0001f)
        {
            audioMixer.SetFloat("Master", -80f); // 최소 볼륨
        }
        else
        {
            float volume = Mathf.Log10(sliderValue) * 20;
            audioMixer.SetFloat("Master", volume);

            // 마스터 볼륨에 따라 BGM과 SFX 볼륨도 업데이트
            SetBGMVolume(bgmVolumeSlider.value);
            SetSFXVolume(sfxVolumeSlider.value);
        }
        SaveVolumeData(); // 볼륨 데이터 저장
    }

    // 효과음(SFX) 볼륨 조정
    public void SetSFXVolume(float sliderValue)
    {
        sfxAudioSource.Stop();

        if (sliderValue <= 0.0001f)
        {
            audioMixer.SetFloat("SFX", -80f);   // 최소 볼륨
        }
        else
        {
            float masterVolume;
            audioMixer.GetFloat("Master", out masterVolume);
            // 마스터 볼륨에 비례하여 효과음 볼륨 조정
            float volume = Mathf.Log10(sliderValue) * 20 + masterVolume;
            audioMixer.SetFloat("SFX", volume);
        }

        sfxAudioSource.PlayOneShot(sfxAudioSource.clip);
        SaveVolumeData(); // 볼륨 데이터 저장
    }

    private void SaveVolumeData()
    {
        VolumeData volumeData = new VolumeData
        {
            bgmVolume = bgmVolumeSlider.value,
            masterVolume = masterVolumeSlider.value,
            sfxVolume = sfxVolumeSlider.value
        };

        string json = JsonUtility.ToJson(volumeData);
        File.WriteAllText(saveFilePath, json);
    }

    private void LoadVolumeData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);

            VolumeData volumeData = JsonUtility.FromJson<VolumeData>(json);

            // 슬라이더 값 설정
            bgmVolumeSlider.value = volumeData.bgmVolume;
            masterVolumeSlider.value = volumeData.masterVolume;
            sfxVolumeSlider.value = volumeData.sfxVolume;

            // 오디오 믹서에 값을 적용
            SetBGMVolume(bgmVolumeSlider.value); // 업데이트된 슬라이더 값을 적용
            SetSFXVolume(sfxVolumeSlider.value);
            SetMasterVolume(masterVolumeSlider.value);
        }
        else
        {
           // 파일이 없을 경우 경고
        }
    }
}