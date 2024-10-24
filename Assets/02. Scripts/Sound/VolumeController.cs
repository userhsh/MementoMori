using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;  // BackgroundMixer�� ����
    public Slider bgmVolumeSlider;
    public Slider masterVolumeSlider;  // ������ ���� �����̴�
    public Slider sfxVolumeSlider;  // ȿ����(SFX) �����̴�

    void Start()
    {
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
            if (sliderValue <= 0.0001f)  // 0�� �ʹ� ����� ���� �����ϱ� ���� ���� ���� ����
            {
                audioMixer.SetFloat("BGM", -80f);  // �ּ� ���� (-80dB�� ����)
            }
            else
            {
                // �����̴� ���� -80dB���� 0dB ���̷� ��ȯ�Ͽ� ����� �ͼ��� ����
                float volume = Mathf.Log10(sliderValue) * 20;
                audioMixer.SetFloat("BGM", volume);
            }
        }

    // ������ ���� ����
    public void SetMasterVolume(float sliderValue)
    {
        if (sliderValue <= 0.0001f)
        {
            audioMixer.SetFloat("Master", -80f);  // �ּ� ����
        }
        else
        {
            float volume = Mathf.Log10(sliderValue) * 20;
            audioMixer.SetFloat("Master", volume);
        }
    }

    // ȿ����(SFX) ���� ����
    public void SetSFXVolume(float sliderValue)
    {
        if (sliderValue <= 0.0001f)
        {
            audioMixer.SetFloat("SFX", -80f);  // �ּ� ����
        }
        else
        {
            float volume = Mathf.Log10(sliderValue) * 20;
            audioMixer.SetFloat("SFX", volume);
        }
    }
}