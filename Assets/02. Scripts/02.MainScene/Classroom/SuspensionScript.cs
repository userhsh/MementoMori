using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuspensionScript : MonoBehaviour
{
    private AudioClip suspensionSound;

    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        suspensionSound = Resources.Load<AudioClip>("ClassroomSFX/SuspensionSound/suspensionSound");

        // 물체를 잡을 때 호출되는 이벤트 연결
        grabInteractable.selectEntered.AddListener(DrawSuspension);
    }

    public void DrawSuspension(SelectEnterEventArgs args)
    {
        audioSource.clip = suspensionSound;
        audioSource.Play();

        // 사운드가 끝난 후에 오브젝트 비활성화 코루틴 시작
        StartCoroutine(DisableAfterSound());
    }

    // 사운드가 끝난 후 오브젝트 비활성화하는 코루틴
    private IEnumerator DisableAfterSound()
    {
        // 사운드 길이만큼 대기
        yield return new WaitForSeconds(audioSource.clip.length);

        // 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}