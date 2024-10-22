using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sink : MonoBehaviour, IInteractable
{
    // �������� ���� ���� �Ǻ� ����
    private bool isTap = false;
    // ���� Ʋ�� ���� ���������� ��ȣ�ۿ� ������ Ȯ�� ����
    private bool isOnTap = false;

    // SinkWater ���� ����
    SinkWater sinkWater = null;
    // waterAnimator ���� ����
    Animator waterAnimator = null;

    private void Awake()
    {
        SinkInit();
    }

    // Sink Init �޼���
    private void SinkInit()
    {
        // ������Ʈ�� ��������
        sinkWater = GetComponentInChildren<SinkWater>();
        waterAnimator = sinkWater.gameObject.GetComponent<Animator>();
        CheckTap();

        // ó���� ���� ���� ���·� �����
        sinkWater.gameObject.SetActive(false);
    }

    // ���������� �ִ� �� üũ�ϴ� �޼���
    private void CheckTap()
    {
        if(SceneManager.GetActiveScene().name != "ClassroomScene") // Sink�� Tap�� �ִ��� �Ǵ��ϴ� �������� ���� �ʿ� -> Count + Coroutine���� ����
        {
            isTap = true;
        }
        else
        {
            isTap = false;
        }    
    }

    public void Interact()
    {
        if (isTap) // ���������� ����뿡 �����Ѵٸ�
        {
            // ��ȣ�ۿ�
            print("Water");
            // ���������� ��ȣ�ۿ��� �� ���� �� Ʋ���� ���� �ϱ� 
            isOnTap = !isOnTap;
            sinkWater.gameObject.SetActive(isOnTap);

            // ���� ���� Ʋ�����ٸ�
            if (sinkWater.gameObject.activeSelf) 
            { 
                // �ִϸ��̼� ���
                waterAnimator.SetTrigger("IsWater");
            }
        }
        else // ���������� ���ٸ�
        {
            // �������� ���� ���
            print("No Tap");
        }
    }
}