using UnityEngine;

public class FindAudioSources : MonoBehaviour
{
    void Start()
    {
        // ��� Audio Source�� ã�Ƽ� ���
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            Debug.Log("Found Audio Source on: " + source.gameObject.name);
        }
    }
}