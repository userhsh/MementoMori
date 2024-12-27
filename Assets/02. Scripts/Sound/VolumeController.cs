using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;   // AudioMixer�� ����
    public Slider bgmVolumeSlider;  // ��� ���� ���� �����̴�
    public Slider masterVolumeSlider; // ������ ���� �����̴�
    public Slider sfxVolumeSlider;  // ȿ����(SFX) �����̴�

    public AudioSource sfxAudioSource;

    private string saveFilePath;

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "volumeData.json");

        // ������ ����� ���� ������ �ε�
        LoadVolumeData();

        // �� ��ȯ �� �����̴��� ����� �ͼ��� �� ����ȭ
        SyncSlidersWithAudioMixer();

        // �����̴� �� ���� �� ���� ����
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void OnEnable()
    {
        // �� ��ȯ �� �����̴��� ����� �ͼ� �� ����ȭ (Ȱ��ȭ�� ��)
        SyncSlidersWithAudioMixer();
    }

    // ����� �ͼ��� �����̴� ���� ����ȭ�ϴ� �Լ�
    void SyncSlidersWithAudioMixer()
    {
        float bgmVolume, masterVolume, sfxVolume;

        // ����� �ͼ��� ���� ���� ���� �޾ƿ� �����̴��� �ݿ�
        audioMixer.GetFloat("BGM", out bgmVolume);
        audioMixer.GetFloat("Master", out masterVolume);
        audioMixer.GetFloat("SFX", out sfxVolume);

        // �����̴��� ����� �ͼ� ���� ��ȯ�ؼ� �ݿ� (dB�� 0~1 ������ ��ȯ)
        bgmVolumeSlider.value = Mathf.Pow(10, bgmVolume / 20);
        masterVolumeSlider.value = Mathf.Pow(10, masterVolume / 20);
        sfxVolumeSlider.value = Mathf.Pow(10, sfxVolume / 20);
    }

    // �����̴� ���� ����� �� ȣ��� �Լ�
    public void SetBGMVolume(float sliderValue)
    {
        // �����̴� ���� 0�� ��� ���Ұ� ���·� ����
        if (sliderValue <= 0.0001f) // 0�� �ʹ� ����� ���� �����ϱ� ���� ���� ���� ����
        {
            audioMixer.SetFloat("BGM", -80f);   // �ּ� ���� (-80dB�� ����)
        }
        else
        {
            float masterVolume;
            audioMixer.GetFloat("Master", out masterVolume);
            // ������ ������ ����Ͽ� ��� ���� ���� ����
            float volume = Mathf.Log10(sliderValue) * 20 + masterVolume;
            audioMixer.SetFloat("BGM", volume);
        }
        SaveVolumeData(); // ���� ������ ����
    }

    public void SetMasterVolume(float sliderValue)
    {
        if (sliderValue <= 0.0001f)
        {
            audioMixer.SetFloat("Master", -80f); // �ּ� ����
        }
        else
        {
            float volume = Mathf.Log10(sliderValue) * 20;
            audioMixer.SetFloat("Master", volume);

            // ������ ������ ���� BGM�� SFX ������ ������Ʈ
            SetBGMVolume(bgmVolumeSlider.value);
            SetSFXVolume(sfxVolumeSlider.value);
        }
        SaveVolumeData(); // ���� ������ ����
    }

    // ȿ����(SFX) ���� ����
    public void SetSFXVolume(float sliderValue)
    {
        sfxAudioSource.Stop();

        if (sliderValue <= 0.0001f)
        {
            audioMixer.SetFloat("SFX", -80f);   // �ּ� ����
        }
        else
        {
            float masterVolume;
            audioMixer.GetFloat("Master", out masterVolume);
            // ������ ������ ����Ͽ� ȿ���� ���� ����
            float volume = Mathf.Log10(sliderValue) * 20 + masterVolume;
            audioMixer.SetFloat("SFX", volume);
        }

        sfxAudioSource.PlayOneShot(sfxAudioSource.clip);
        SaveVolumeData(); // ���� ������ ����
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

            // �����̴� �� ����
            bgmVolumeSlider.value = volumeData.bgmVolume;
            masterVolumeSlider.value = volumeData.masterVolume;
            sfxVolumeSlider.value = volumeData.sfxVolume;

            // ����� �ͼ��� ���� ����
            SetBGMVolume(bgmVolumeSlider.value); // ������Ʈ�� �����̴� ���� ����
            SetSFXVolume(sfxVolumeSlider.value);
            SetMasterVolume(masterVolumeSlider.value);
        }
        else
        {
           // ������ ���� ��� ���
        }
    }
}