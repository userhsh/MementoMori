using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TapScript : MonoBehaviour
{
    // ����� ���ϰ� ����� �ҽ� ������Ʈ�� ������ ����
    private AudioClip waterSound; // �� �帣�� �Ҹ� Ŭ��
    private AudioSource audioSource;  // ����� �ҽ�
    private XRGrabInteractable grabInteractable; // XR ��ȣ�ۿ��� ���� ������Ʈ
    public bool isTurnOn = false; // ���������� ���� �ִ��� ���θ� Ȯ���ϴ� ����
    private Animator animator; // �ִϸ��̼� ��Ʈ�ѷ�

    // ������Ʈ�� ������ �� ������Ʈ�� �ʱ�ȭ�ϴ� �Լ�
    private void Awake()
    {
        // ����� �ҽ�, XR ��ȣ�ۿ� ������Ʈ, �ִϸ�����, ���� ��Ʈ�ѷ� �ʱ�ȭ
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        animator = GetComponent<Animator>();
    }

    // ������ �� ����� Ŭ���� �ҷ����� �̺�Ʈ�� �����ϴ� �Լ�
    private void Start()
    {
        // �� �帣�� �Ҹ� ������ ���ҽ����� �ҷ���
        waterSound = Resources.Load<AudioClip>("ClassroomSFX/WaterSound/watersound");

        // XR ��ġ�� ��ü�� ���� ���� �̺�Ʈ�� TurnOnWater �޼��带 ����
        grabInteractable.selectEntered.AddListener(TurnOnWater);
    }

    // ���������� �Ѵ� �޼���, XR ��ȣ�ۿ� �̺�Ʈ���� ȣ���
    public void TurnOnWater(SelectEnterEventArgs args)
    {
        isTurnOn = true; // ���� ���¸� ����(true)���� ����
        animator.SetBool("isTurnOn", true); // �ִϸ��̼��� ����ϵ��� ����

        // ����� �ҽ��� �� �Ҹ� Ŭ���� �����ϰ� ���
        audioSource.clip = waterSound;
        audioSource.Play();

        // ����� �ý��� �ð��� ���� 2.5�� �Ŀ� ����ǵ��� ����
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + 2.5f);

        // �÷��̾��� ���� ��ġ�� ȸ�� ���¸� ���� �����ͷ� ����
        GameManager.GetInstance().SaveGameData(
            FindObjectOfType<PlayerController>().transform.position,
            FindAnyObjectByType<PlayerController>().transform.rotation.eulerAngles
        );
    }
}
