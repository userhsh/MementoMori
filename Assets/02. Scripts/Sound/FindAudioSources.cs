using UnityEngine;

public class FindAudioSources : MonoBehaviour
{
    void Start()
    {
        // 모든 Audio Source를 찾아서 출력
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
        }
    }
}