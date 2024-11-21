using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuspensionScript : MonoBehaviour
{
    // ���� Ŭ���� ����� �ҽ��� ������ ����
    private AudioClip suspensionSound; // suspension �Ҹ� Ŭ��
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ
    private XRGrabInteractable grabInteractable; // XR ��ȣ�ۿ� ������Ʈ

    // ������Ʈ�� ������ �� �ʿ��� ������Ʈ�� �ʱ�ȭ�ϴ� �Լ�
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // ����� �ҽ� ��������
        grabInteractable = GetComponent<XRGrabInteractable>(); // XRGrabInteractable ��������
    }

    // ���� ��, �Ҹ� Ŭ���� �ҷ����� �̺�Ʈ�� �����ϴ� �Լ�
    private void Start()
    {
        // ���ҽ� �������� ������� �Ҹ��� �ҷ���
        suspensionSound = Resources.Load<AudioClip>("ClassroomSFX/SuspensionSound/suspensionSound");

        // XR ��ȣ�ۿ� �̺�Ʈ�� DrawSuspension �޼��带 ����
        grabInteractable.selectEntered.AddListener(DrawSuspension);
    }

    // XR ��ȣ�ۿ� �̺�Ʈ �߻� ��, �Ҹ��� ����ϰ� ��Ȱ��ȭ �ڷ�ƾ�� �����ϴ� �޼���
    public void DrawSuspension(SelectEnterEventArgs args)
    {
        audioSource.clip = suspensionSound; // ����� �ҽ��� ������� �Ҹ� ����
        audioSource.Play(); // �Ҹ� ���

        // �Ҹ��� ���� �� ������Ʈ ��Ȱ��ȭ �ڷ�ƾ�� ����
        StartCoroutine(DisableAfterSound());
    }

    // ���尡 ���� �� ������Ʈ�� ��Ȱ��ȭ�ϴ� �ڷ�ƾ �Լ�
    private IEnumerator DisableAfterSound()
    {
        // ���� ��� �ð��� ���� ������ ���
        yield return new WaitForSeconds(audioSource.clip.length);

        // ������Ʈ�� ��Ȱ��ȭ�Ͽ� ��鿡�� ������ �ʵ��� ����
        gameObject.SetActive(false);
    }
}
