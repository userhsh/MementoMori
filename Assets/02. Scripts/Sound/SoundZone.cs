using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour, IEffectable
{
    private AudioSource audioSource; // 소리를 재생할 AudioSource
    public float fadeDuration = 1.0f; // 소리 페이드 아웃 시간
    private bool isPlaying = false; // 소리 재생 중 여부를 추적하는 변수
    float startVolume = 1f; // 초기 볼륨

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
        if (!isPlaying) // 소리가 재생 중이지 않다면
        {
            isPlaying = true; // 소리 재생 시작           
            audioSource.Play(); // 플레이어가 영역에 들어왔을 때
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration); // 볼륨을 서서히 줄임
            yield return null; // 다음 프레임까지 대기
        }
        audioSource.Stop(); // 볼륨이 0이 되면 소리 정지
        audioSource.volume = startVolume; // 볼륨을 초기값으로 복원
    }

    public void FadeOutRainSound()
    {
        StartCoroutine(FadeOut(audioSource, fadeDuration));
    }
}