using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuspensionScript : MonoBehaviour
{
    // 사운드 클립과 오디오 소스를 저장할 변수
    private AudioClip suspensionSound; // suspension 소리 클립
    private AudioSource audioSource; // 오디오 소스 컴포넌트
    private XRGrabInteractable grabInteractable; // XR 상호작용 컴포넌트

    // 오브젝트가 생성될 때 필요한 컴포넌트를 초기화하는 함수
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // 오디오 소스 가져오기
        grabInteractable = GetComponent<XRGrabInteractable>(); // XRGrabInteractable 가져오기
    }

    // 시작 시, 소리 클립을 불러오고 이벤트를 설정하는 함수
    private void Start()
    {
        // 리소스 폴더에서 서스펜션 소리를 불러옴
        suspensionSound = Resources.Load<AudioClip>("ClassroomSFX/SuspensionSound/suspensionSound");

        // XR 상호작용 이벤트에 DrawSuspension 메서드를 연결
        grabInteractable.selectEntered.AddListener(DrawSuspension);
    }

    // XR 상호작용 이벤트 발생 시, 소리를 재생하고 비활성화 코루틴을 시작하는 메서드
    public void DrawSuspension(SelectEnterEventArgs args)
    {
        audioSource.clip = suspensionSound; // 오디오 소스에 서스펜션 소리 설정
        audioSource.Play(); // 소리 재생

        // 소리가 끝난 후 오브젝트 비활성화 코루틴을 시작
        StartCoroutine(DisableAfterSound());
    }

    // 사운드가 끝난 후 오브젝트를 비활성화하는 코루틴 함수
    private IEnumerator DisableAfterSound()
    {
        // 사운드 재생 시간이 끝날 때까지 대기
        yield return new WaitForSeconds(audioSource.clip.length);

        // 오브젝트를 비활성화하여 장면에서 보이지 않도록 설정
        gameObject.SetActive(false);
    }
}
