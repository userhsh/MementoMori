using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Groove2 : MonoBehaviour
{
    public GameObject[] Numbers; // ���� ������Ʈ �迭
    public bool CorrectB = false; // ���� 1�� �ùٸ��� ����
    public GameObject SuccessText; // ���� �ؽ�Ʈ UI
    public GameObject Password; // ��й�ȣ ������Ʈ
    public bool IsWrong = false; // �߸��� ���� �Է� ����

    // ���� 1�� �浹 �� �ùٸ� �Է� üũ
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1�� ���� Ȯ��
        {
            CorrectB = true; // ���� ����
        }
        else
        {
            // "SpotLight" �� �ٸ� ������Ʈ�� �浹 �� �߸��� �Է�
            if (!other.CompareTag("SpotLight"))
            {
                IsWrong = true;
            }
        }
    }

    // ���� 1���� ����� �� ���� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1�� ���� üũ
        {
            CorrectB = false; // ���� ���� ����
        }
        else
        {
            // "SpotLight" �� �ٸ� ������Ʈ���� ����� �� �߸��� �Է� ����
            if (!other.CompareTag("SpotLight"))
            {
                IsWrong = false;
            }
        }
    }
}
