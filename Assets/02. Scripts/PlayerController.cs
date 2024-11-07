using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager; // GameManager�� �����ϴ� ����

    // ī�޶� ������ ���� ����
    private CameraOffset cameraOffset;

    // �������̽� ���� ����
    private IEffectable effectable;
    private IShakable shakable;

    // ī�޶� �⺻ ��ġ ���� ����
    Vector3 cameraOffsetOriginPosition;

    int shakeCount = 0;

    void Awake()
    {
        // ������ GameManager�� ã�� gameManager ������ �Ҵ�
        gameManager = FindObjectOfType<GameManager>();
        // ī�޶� ������ ��������
        cameraOffset = GetComponentInChildren<CameraOffset>();

        // ���� GameManager�� ���� �������� �ʴ´ٸ�, �α׸� ����ϰ� �� �̻� �������� ����
        if (gameManager == null)
        {
            Debug.Log("GameManager not found in the scene!"); // �α� �߰�
            return; // GameManager�� ���� ��� �޼��� ����
        }

        // GameManager���� ����� GameData�� �ҷ���
        GameData loadedData = gameManager.LoadGameData();

        // �ҷ��� �����Ͱ� ������ ���, �÷��̾��� ��ġ�� �ش� �������� ��ġ�� ����
        if (loadedData != null && loadedData.playerPosition != null) // playerPosition�� null���� üũ
        {
            transform.position = loadedData.playerPosition; // �÷��̾ �ε��� ��ġ�� �̵�
            transform.rotation = Quaternion.Euler(loadedData.playerRotation); // �÷��̾��� ȸ���� �ε��� ȸ�������� ����
        }
        else
        {
            //Debug.Log("Loaded data is null or player position is not set. Setting player to default position.");
            // �ʿ� �� �⺻������ ����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �������̽� ��������
        effectable = other.GetComponent<IEffectable>();
        shakable = other.GetComponent<IShakable>();

        // Ʈ���� ����Ʈ ����
        effectable?.TriggerEffect();

        // ����ũ ���� Ȯ��
        if (shakable != null)
        {
            if (shakeCount > 2) return;

            StartShakeCamera();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        effectable = collision.collider.gameObject.GetComponent<IEffectable>();

        effectable?.TriggerEffect();
    }

    private void StartShakeCamera()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        // ����ũ �� �� ������ �ڷ�ƾ Ż��
        if (shakable == null) yield break;

        // ����ũ �ð� 
        float shakeTime = 0;
        // ī�޶� ���� ��ġ ��������
        cameraOffsetOriginPosition = cameraOffset.transform.localPosition;

        // 0.5�ʵ���
        while (shakeTime < 1f)
        {
            // ī�޶� cameraOffsetOriginPosition ��ġ���� 0.1 ũ���� ������ �����ϰ� ����
            cameraOffset.transform.localPosition = Random.insideUnitSphere * 0.1f + cameraOffsetOriginPosition;

            shakeTime += Time.deltaTime;
            yield return null;
        }

        // ī�޶� ��ġ ������� ������
        cameraOffset.transform.localPosition = cameraOffsetOriginPosition;
        shakeCount++;
    }
}