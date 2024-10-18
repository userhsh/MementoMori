using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TapScript : MonoBehaviour
{
    private AudioClip waterSound;

    private AudioSource audioSource;  // ����� �ҽ�
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
        // ��ü�� ���� �� ȣ��Ǵ� �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(TurnOnWater);
    }

    public void TurnOnWater(SelectEnterEventArgs args)
    {
        Debug.Log("�������� Ʋ��");
        animator.SetBool("isTurnOn", true);

        audioSource.clip = waterSound;
        audioSource.Play();
        // ���� ����� �ý��� �ð��� 2�� �Ŀ� �����ϵ��� ����
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + 2.5f);
    }
}
