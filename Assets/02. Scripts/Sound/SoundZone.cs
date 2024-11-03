using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour, IEffectable
{
    private AudioSource audioSource; // �Ҹ��� ����� AudioSource
    public float fadeDuration = 1.0f; // �Ҹ� ���̵� �ƿ� �ð�
    private bool isPlaying = false; // �Ҹ� ��� �� ���θ� �����ϴ� ����
    float startVolume = 1f; // �ʱ� ����

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPlaying)
        {
            FadeOutRainSound();
            isPlaying = false;
        }
    }

    public void TriggerEffect()
    {
        if (!isPlaying) // �Ҹ��� ��� ������ �ʴٸ�
        {
            isPlaying = true; // �Ҹ� ��� ����           
            audioSource.Play(); // �÷��̾ ������ ������ ��
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration); // ������ ������ ����
            yield return null; // ���� �����ӱ��� ���
        }
        audioSource.Stop(); // ������ 0�� �Ǹ� �Ҹ� ����
        audioSource.volume = startVolume; // ������ �ʱⰪ���� ����
    }

    public void FadeOutRainSound()
    {
        StartCoroutine(FadeOut(audioSource, fadeDuration));
    }
}