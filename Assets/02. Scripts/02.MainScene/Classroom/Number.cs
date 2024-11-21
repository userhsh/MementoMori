using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Number : MonoBehaviour
{
    // Ư�� ���ڸ� Ȱ��ȭ/��Ȱ��ȭ�ϴ� �� ����� GameObject ����
    public GameObject Number9, Number1;
    private XRGrabInteractable grabinteractable;  // XR ��ȣ�ۿ��� ���� XRGrabInteractable ������Ʈ
    private Vector3 originalParentPosition;      // �θ� ��ü�� ���� ��ġ
    private Quaternion originalParentRotation;   // �θ� ��ü�� ���� ȸ����
    private Vector3 originalLocalChildPositions; // �ڽ� ��ü�� ���� ���� ��ġ
    private Quaternion originalLocalChildRotations; // �ڽ� ��ü�� ���� ���� ȸ����
    private Groove1 groove1;  // Groove1 ��ũ��Ʈ ����
    private Groove2 groove2;  // Groove2 ��ũ��Ʈ ����

    private void Awake()
    {
        // XRGrabInteractable, Groove1, Groove2 ������Ʈ�� �ʱ�ȭ
        grabinteractable = GetComponent<XRGrabInteractable>();
        groove1 = FindObjectOfType<Groove1>();
        groove2 = FindObjectOfType<Groove2>();
    }

    private void Start()
    {
        // XR ��ȣ�ۿ� �̺�Ʈ ����
        grabinteractable.selectExited.AddListener(OnRelease);  // ���� �� ȣ��
        grabinteractable.activated.AddListener(TriggerOn);    // Ʈ���� ��ư�� ���� �� ȣ��

        // �θ� ��ü�� ���� ��ġ�� ȸ������ ���� (���� ��ǥ)
        originalParentPosition = transform.position;
        originalParentRotation = transform.rotation;

        // �ڽ� ��ü�� ���� ���� ��ġ�� ȸ������ ����
        originalLocalChildPositions = transform.localPosition;
        originalLocalChildRotations = transform.localRotation;
    }

    // ��ü�� ������ �� ȣ��Ǵ� �Լ�
    private void OnRelease(SelectExitEventArgs args)
    {
        // �θ� ��ü�� ��ġ�� ȸ������ ������� ���� (���� ��ǥ)
        transform.position = originalParentPosition;
        transform.rotation = originalParentRotation;

        // �ڽ� ��ü�� ���� ��ġ�� ȸ������ ������� ����
        transform.localPosition = originalLocalChildPositions;
        transform.localRotation = originalLocalChildRotations;
    }

    // Ʈ���� ��ư�� ������ �� ȣ��Ǵ� �Լ�
    private void TriggerOn(ActivateEventArgs args)
    {
        // Groove1���� ������ ������ ���
        if (groove1.CorrectA)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[1]); // ���� �Ҹ� ���

            groove1.Numbers[8].SetActive(false); // 9�� ���� ��Ȱ��ȭ
            Number9.SetActive(true);             // Number9 Ȱ��ȭ
            groove1.Numbers[8].GetComponent<Collider>().enabled = false; // �浹 ��Ȱ��ȭ

            groove1.CorrectA = false; // ���� ���¸� �ʱ�ȭ

            return; // �Լ� ����
        }

        // Groove2���� ������ ������ ���
        if (groove2.CorrectB)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[1]); // ���� �Ҹ� ���

            groove1.Numbers[0].SetActive(false); // 1�� ���� ��Ȱ��ȭ
            Number1.SetActive(true);             // Number1 Ȱ��ȭ
            groove1.Numbers[0].GetComponent<Collider>().enabled = false; // �浹 ��Ȱ��ȭ

            groove2.CorrectB = false; // ���� ���� �ʱ�ȭ

            return; // �Լ� ����
        }

        // Groove1 �Ǵ� Groove2���� ������ ���
        if (groove1.isWrong == true && !groove1.audioSource.isPlaying)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[0]); // ���� �Ҹ� ���
        }

        if (groove2.IsWrong == true && !groove1.audioSource.isPlaying)
        {
            groove1.audioSource.PlayOneShot(groove1.audioClip[0]); // ���� �Ҹ� ���
        }
    }
}
