using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;   // ������ ������ �����̴�
    public AudioSource audioSource;  // ����� �ҽ�

    private void Start()
    {
        // PlayerPrefs���� ����� ���� ���� �ҷ��� ����
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;  // �����̴��� ����� �� �ݿ�
            audioSource.volume = savedVolume;  // ����� �ҽ��� ����� �� �ݿ�
        }
        else
        {
            // ����� ���� ������ �⺻ �� 1�� ����
            volumeSlider.value = 1;
            audioSource.volume = 1;
        }

        // �����̴� ���� ����� �� ������ ����
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // �����̴� ���� ������� ������ �����ϴ� �Լ�
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;  // ����� ������ �����̴� ������ ����
        PlayerPrefs.SetFloat("Volume", volume);  // ���� ���� ����
        PlayerPrefs.Save();  // PlayerPrefs ����
    }
}