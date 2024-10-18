using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TapScript : MonoBehaviour
{
    private AudioClip waterSound;

    private AudioSource audioSource;  // 오디오 소스
    private XRGrabInteractable grabInteractable;

    Animator animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        waterSound = Resources.Load<AudioClip>("WaterSound/watersound");
        // 물체를 잡을 때 호출되는 이벤트 연결
        grabInteractable.selectEntered.AddListener(TurnOnWater);
    }

    public void TurnOnWater(SelectEnterEventArgs args)
    {
        Debug.Log("수도꼭지 틀기");
        animator.SetBool("isTurnOn", true);

        audioSource.clip = waterSound;
        audioSource.Play();
        // 현재 오디오 시스템 시간에 2초 후에 종료하도록 예약
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + 2.5f);
    }
}
