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

        // ��ü�� ���� �� ȣ��Ǵ� �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(DrawSuspension);
    }

    public void DrawSuspension(SelectEnterEventArgs args)
    {
        audioSource.clip = suspensionSound;
        audioSource.Play();

        // ���尡 ���� �Ŀ� ������Ʈ ��Ȱ��ȭ �ڷ�ƾ ����
        StartCoroutine(DisableAfterSound());
    }

    // ���尡 ���� �� ������Ʈ ��Ȱ��ȭ�ϴ� �ڷ�ƾ
    private IEnumerator DisableAfterSound()
    {
        // ���� ���̸�ŭ ���
        yield return new WaitForSeconds(audioSource.clip.length);

        // ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}