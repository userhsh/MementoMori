using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHole : MonoBehaviour, IInteractable
{
    // ��ȣ�ۿ� �������� Ȯ���� bool�� ����
    bool isInteractable = false;

    // Ʈ���� �ߵ� ��
    private void OnTriggerEnter(Collider other)
    {
        // ���� �浹�� ��ü�� ���� ��ư�̸�
        if (other.gameObject.name == "ShutterButton")
        {
            // ��ȣ�ۿ� ����
            isInteractable = true;
        }
    }

    // Ʈ���Ű� ������ ��
    private void OnTriggerExit(Collider other)
    {
        // ���� ���� ��ư�� �浹�� �����ٸ�
        if (other.gameObject.name == "ShutterButton")
        {
            // ��ȣ�ۿ� �Ұ���
            isInteractable = false;
        }
    }

    public void Interact()
    {
        // ��ȣ�ۿ� ������ ���°� �ƴҶ� ���ư���
        if (!isInteractable) return;

        // Resources �������� ���� ���� ��ư ������ ��������
        GameObject mainShutterButton = Resources.Load("Prefabs/MainShutterButton") as GameObject;

        // ���� ���� ��ư ����
        Instantiate(mainShutterButton, this.transform.position, this.transform.rotation);

        // ��ư Ȧ ����
        Destroy(gameObject);
    }
}