using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHole : MonoBehaviour, IInteractable
{
    // ��ȣ�ۿ� �������� Ȯ���� bool�� ����
    bool isInteractable = false;

    public SurgeryShutterButton surgeryShutterButton;

    public ShutterButton shutterButton;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        surgeryShutterButton.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� �浹�� ��ü�� ���� ��ư�̸�
        if (collision.collider.gameObject.name == "ShutterButton")
        {
            // ��ȣ�ۿ� ����
            isInteractable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // ���� ���� ��ư�� �浹�� �����ٸ�
        if (collision.collider.gameObject.name == "ShutterButton")
        {
            // ��ȣ�ۿ� �Ұ���
            isInteractable = false;
        }
    }
        
    public void Interact()
    {
        // ��ȣ�ۿ� ������ ���°� �ƴҶ� ���ư���
        if (!isInteractable) return;

        surgeryShutterButton.gameObject.SetActive(true);

        audioSource.PlayOneShot(audioClip);

        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        // ���� ��ư ����
        Destroy(shutterButton.gameObject);
        // ��ư Ȧ ����
        Destroy(this.gameObject, audioClip.length);
    }
}