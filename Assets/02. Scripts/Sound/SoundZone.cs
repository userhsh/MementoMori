using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour
{
    private AudioSource audioSource; // �Ҹ��� ����� AudioSource
    public float fadeDuration = 1.0f; // �Ҹ� ���̵� �ƿ� �ð�

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            audioSource.Play(); // �÷��̾ ������ ������ ��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PLAYER"))
        {
            StartCoroutine(FadeOut(audioSource, fadeDuration)); // �÷��̾ ������ ����� ��
        }        
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume; // �ʱ� ����
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration); // ������ ������ ����
            yield return null; // ���� �����ӱ��� ���
        }
        audioSource.Stop(); // ������ 0�� �Ǹ� �Ҹ� ����
        audioSource.volume = startVolume; // ������ �ʱⰪ���� ����
    }
}
