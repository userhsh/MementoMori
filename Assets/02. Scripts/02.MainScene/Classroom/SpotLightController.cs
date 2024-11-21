using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    private Light spotLight; // ����Ʈ����Ʈ Light ������Ʈ�� �����ϴ� ����
    private float blinkInterval = 0.5f; // ����Ʈ����Ʈ ������ ������ ���� (0.5�� ����)
    private Coroutine blinkCoroutine; // ������ �ڷ�ƾ�� �����ϱ� ���� ����

    private void Awake()
    {
        // ����Ʈ����Ʈ Light ������Ʈ�� �����ͼ� �ʱ�ȭ
        spotLight = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���ſ� �浹�� ��ü�� "Body" �±׸� ���� ���
        if (other.CompareTag("Body"))
        {
            // ������ �ڷ�ƾ ����
            blinkCoroutine = StartCoroutine(BlinkLight());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Ʈ���ſ��� ��ü�� ���� �� "Body" �±׸� ���� ���
        if (other.CompareTag("Body"))
        {
            // ������ �ڷ�ƾ ����
            StopCoroutine(blinkCoroutine);
        }
    }

    // ����Ʈ����Ʈ�� �����̰� �ϴ� �ڷ�ƾ
    private IEnumerator BlinkLight()
    {
        while (true)
        {
            // ����Ʈ����Ʈ�� Ȱ�� ���¸� ���� (���� <-> ����)
            spotLight.enabled = !spotLight.enabled;

            // ������ ������ ���ݸ�ŭ ���
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
