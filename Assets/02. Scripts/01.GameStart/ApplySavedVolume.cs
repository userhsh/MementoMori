using UnityEngine;

public class ApplySavedVolume : MonoBehaviour
{
    public AudioSource audioSource;  // �� ���� ����� �ҽ�

    private void Start()
    {
        // PlayerPrefs���� ����� ���� ���� �ҷ��� ����� �ҽ��� ����
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioSource.volume = savedVolume;
        }
        else
        {
            // ����� ���� ������ �⺻ ������ 1�� ����
            audioSource.volume = 1;
        }
    }
}