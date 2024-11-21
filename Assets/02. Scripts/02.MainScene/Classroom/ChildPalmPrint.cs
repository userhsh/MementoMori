using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ChildPalmPrint : MonoBehaviour
{
    private AudioClip collectionSound; // ����ǰ ȹ�� �� ����� ����� Ŭ��
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    private XRGrabInteractable grabInteractable; // XR ��ȣ�ۿ��� ���� ������Ʈ

    private void Awake()
    {
        // ����� �ҽ� ������Ʈ�� �����ͼ� �ʱ�ȭ
        audioSource = GetComponent<AudioSource>();
        // XRGrabInteractable ������Ʈ�� �����ͼ� �ʱ�ȭ (VR���� ��ȣ�ۿ� �����ϰ� ��)
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        // ���ҽ� �������� ����ǰ ���� ������ �ε�
        collectionSound = Resources.Load<AudioClip>("TutorialSFX/PaperSFX");

        // ��ü�� ����� �� ȣ��Ǵ� �̺�Ʈ ������ �߰�
        grabInteractable.selectEntered.AddListener(OnGrabbed);

        // ó������ ������Ʈ�� ��Ȱ��ȭ ���·� ����
        gameObject.SetActive(false);
    }

    // ��ü�� ������ �� ȣ��Ǵ� �Լ�
    public void OnGrabbed(SelectEnterEventArgs args)
    {
        // ����ǰ ȹ�� ��, UIManager�� �÷��� �迭�� ������Ʈ�Ͽ� ��ư�� �ر�
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[0] = true;
        // ���� ��ȭ ī��Ʈ ����
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collectTalkCount++;
        // UIManager�� ���� ��ȭ ī��Ʈ ����
        GameObject.Find("PlayerUI").GetComponent<UIManager>().CollectGetTalkCount();

        // ����� �ҽ��� ����ǰ ���� ���� �� ���
        audioSource.clip = collectionSound;
        audioSource.Play();

        // ����ǰ �̹����� �浹 ������ ��Ȱ��ȭ�Ͽ� �ٽ� ��ȣ�ۿ��� �ȵǵ��� ����
        this.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
