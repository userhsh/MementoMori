using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    // ���� ������ ���� ���� ����
    ShutterPrice[] shutterPrices = null;

    private void Awake()
    {
        shutterPrices = GetComponentsInChildren<ShutterPrice>();
    }

    // ���� �����ϴ� �޼���(�ܺ� ȣ���)
    public void DestroyShutter()
    {
        StartCoroutine(DestroyShutterCo());
    }

    // ���� �����ϴ� �ڷ�ƾ
    IEnumerator DestroyShutterCo()
    {
        // ��� ���� ������ ���� ���� �Ʒ� ���� ����
        for (int i = 0; i < shutterPrices.Length; i++)
        {
            // ���� ���� ������� �ϱ�
            Destroy(shutterPrices[i]);
            // 0.1�� ���
            yield return new WaitForSeconds(0.1f);
        }
    }
}