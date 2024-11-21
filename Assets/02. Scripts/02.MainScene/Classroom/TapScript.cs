using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TapScript : MonoBehaviour
{
    // 오디오 파일과 오디오 소스 컴포넌트를 저장할 변수
    private AudioClip waterSound; // 물 흐르는 소리 클립
    private AudioSource audioSource;  // 오디오 소스
    private XRGrabInteractable grabInteractable; // XR 상호작용을 위한 컴포넌트
    public bool isTurnOn = false; // 수도꼭지가 켜져 있는지 여부를 확인하는 변수
    private Animator animator; // 애니메이션 컨트롤러

    // 오브젝트가 생성될 때 컴포넌트를 초기화하는 함수
    private void Awake()
    {
        // 오디오 소스, XR 상호작용 컴포넌트, 애니메이터, 조명 컨트롤러 초기화
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        animator = GetComponent<Animator>();
    }

    // 시작할 때 오디오 클립을 불러오고 이벤트를 설정하는 함수
    private void Start()
    {
        // 물 흐르는 소리 파일을 리소스에서 불러옴
        waterSound = Resources.Load<AudioClip>("ClassroomSFX/WaterSound/watersound");

        // XR 장치로 물체를 잡을 때의 이벤트에 TurnOnWater 메서드를 연결
        grabInteractable.selectEntered.AddListener(TurnOnWater);
    }

    // 수도꼭지를 켜는 메서드, XR 상호작용 이벤트에서 호출됨
    public void TurnOnWater(SelectEnterEventArgs args)
    {
        isTurnOn = true; // 수도 상태를 켜짐(true)으로 설정
        animator.SetBool("isTurnOn", true); // 애니메이션을 재생하도록 설정

        // 오디오 소스에 물 소리 클립을 설정하고 재생
        audioSource.clip = waterSound;
        audioSource.Play();

        // 오디오 시스템 시간에 따라 2.5초 후에 종료되도록 예약
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + 2.5f);

        // 플레이어의 현재 위치와 회전 상태를 게임 데이터로 저장
        GameManager.GetInstance().SaveGameData(
            FindObjectOfType<PlayerController>().transform.position,
            FindAnyObjectByType<PlayerController>().transform.rotation.eulerAngles
        );
    }
}
