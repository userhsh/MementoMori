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

    private bool isInsideCollider = false;  // 콜라이더 안에 있는지 체크하는 변수

    private void Awake()
    {
        grabinteractable = GetComponent<XRGrabInteractable>();
        groove1 = FindObjectOfType<Groove1>();
        groove2 = FindObjectOfType<Groove2>();
    }

    private void Start()
    {
        grabinteractable.selectExited.AddListener(OnRelease);

        // 부모 객체의 원래 위치와 회전값을 저장 (월드 좌표)
        originalParentPosition = transform.position;
        originalParentRotation = transform.rotation;

        // 자식 객체들의 원래 로컬 위치와 회전값을 저장
        originalLocalChildPositions = transform.localPosition;
        originalLocalChildRotations = transform.localRotation;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (groove1.CorrectA)
        {
            groove1.Numbers[8].SetActive(false); // 비활성화
            Number9.SetActive(true);

            groove1.Numbers[8].GetComponent<Collider>().enabled = false;

            transform.rotation = originalParentRotation;
            transform.localRotation = originalLocalChildRotations;

            groove1.CorrectA = false;
            return;
        }

        if (groove2.CorrectB)
        {
            groove1.Numbers[0].SetActive(false); // 비활성화
            Number1.SetActive(true);

            groove1.Numbers[0].GetComponent<Collider>().enabled = false;

            transform.rotation = originalParentRotation;
            transform.localRotation = originalLocalChildRotations;
            groove2.CorrectB = false;
            return;
        }

        // 부모 객체의 월드 좌표를 원래대로 되돌리기
        transform.position = originalParentPosition;
        transform.rotation = originalParentRotation;

        // 자식 객체의 로컬 위치와 회전값을 원래대로 되돌리기
        transform.localPosition = originalLocalChildPositions;
        transform.localRotation = originalLocalChildRotations;
    }
}
