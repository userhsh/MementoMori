using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Number : MonoBehaviour
{
    public GameObject Number9, Number1;

    private XRGrabInteractable grabinteractable;

    private Vector3 originalParentPosition;
    private Quaternion originalParentRotation;
    private Vector3 originalLocalChildPositions;
    private Quaternion originalLocalChildRotations;

    private Groove1 groove1;
    private Groove2 groove2;

    private bool isInsideCollider = false;  // �ݶ��̴� �ȿ� �ִ��� üũ�ϴ� ����

    private void Awake()
    {
        grabinteractable = GetComponent<XRGrabInteractable>();
        groove1 = FindObjectOfType<Groove1>();
        groove2 = FindObjectOfType<Groove2>();
    }

    private void Start()
    {
        grabinteractable.selectExited.AddListener(OnRelease);

        // �θ� ��ü�� ���� ��ġ�� ȸ������ ���� (���� ��ǥ)
        originalParentPosition = transform.position;
        originalParentRotation = transform.rotation;

        // �ڽ� ��ü���� ���� ���� ��ġ�� ȸ������ ����
        originalLocalChildPositions = transform.localPosition;
        originalLocalChildRotations = transform.localRotation;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (groove1.CorrectA)
        {
            groove1.Numbers[8].SetActive(false); // ��Ȱ��ȭ
            Number9.SetActive(true);

            groove1.Numbers[8].GetComponent<Collider>().enabled = false;

            transform.rotation = originalParentRotation;
            transform.localRotation = originalLocalChildRotations;

            groove1.CorrectA = false;
            return;
        }

        if (groove2.CorrectB)
        {
            groove1.Numbers[0].SetActive(false); // ��Ȱ��ȭ
            Number1.SetActive(true);

            groove1.Numbers[0].GetComponent<Collider>().enabled = false;

            transform.rotation = originalParentRotation;
            transform.localRotation = originalLocalChildRotations;
            groove2.CorrectB = false;
            return;
        }

        // �θ� ��ü�� ���� ��ǥ�� ������� �ǵ�����
        transform.position = originalParentPosition;
        transform.rotation = originalParentRotation;

        // �ڽ� ��ü�� ���� ��ġ�� ȸ������ ������� �ǵ�����
        transform.localPosition = originalLocalChildPositions;
        transform.localRotation = originalLocalChildRotations;
    }
}
