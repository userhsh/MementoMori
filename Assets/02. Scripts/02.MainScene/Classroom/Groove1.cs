using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Groove1 : MonoBehaviour
{
    public GameObject[] Numbers;  // ���� ������Ʈ �迭
    public bool CorrectA = false; // ���� 9�� �ùٸ��� ����
    public GameObject SuccessText; // ���� �ؽ�Ʈ UI
    public Groove2 groove2; // Groove2 ��ü ����
    public GameObject Password; // ��й�ȣ ������Ʈ
    public bool isFog = false; // �Ȱ� ���� üũ
    public AudioSource audioSource; // ����� �ҽ�
    public AudioClip[] audioClip; // ����� Ŭ�� �迭
    public bool isWrong = false; // �߸��� ���� �Է� ����

    // �ʱ�ȭ �� ����� �ҽ� ������Ʈ �Ҵ�
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ���� ���� ��, ���� ���� �ڷ�ƾ ����
    private void Start()
    {
        StartCoroutine(Correct());
    }

    // ���� ������Ʈ�� �浹 ��, �ùٸ� ���� üũ
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Numbers[8]) // 9�� ���� Ȯ��
        {
            CorrectA = true; // ����
        }
        else
        {
            // "SpotLight"�� �ƴ� �ٸ� ������Ʈ�� �浹 �� �߸��� �Է�
            if (!other.CompareTag("SpotLight"))
            {
                isWrong = true;
            }
        }
    }

    // ���� ������Ʈ���� ����� ��, ���� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Numbers[8]) // 9�� ���� üũ
        {
            CorrectA = false; // ���� ���� ����
        }
        else
        {
            // "SpotLight"�� �ƴ� �ٸ� ������Ʈ���� ����� �� �߸��� �Է� ����
            if (!other.CompareTag("SpotLight"))
            {
                isWrong = false;
            }
        }
    }

    // ���� Ȯ�� �� ���� ó��
    private IEnumerator Correct()
    {
        // 9�� �Ǵ� 1�� ���� ������Ʈ�� �ݶ��̴��� Ȱ��ȭ���� ������ ��� ��ٸ�
        while (Numbers[8].GetComponent<Collider>().enabled == true || Numbers[0].GetComponent<Collider>().enabled == true)
        {
            yield return null;
        }

        SuccessText.SetActive(true); // ���� �ؽ�Ʈ ǥ��
        Password.SetActive(true); // ��й�ȣ ������Ʈ Ȱ��ȭ
        isFog = true; // �Ȱ� ���� Ȱ��ȭ

        Invoke("CorrectTalkText", 3); // 3�� �� "���Ⱑ ���� �� ����." ��� ����
    }

    // ���� �� ��� ����
    void CorrectTalkText()
    {
        // UI���� ��� ó��
        if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
        {
            StartCoroutine(GameObject.Find("PlayerUI").GetComponent<UITalk>().InteractionTalk("The steam stopped."));
        }
        else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
        {
            StartCoroutine(GameObject.Find("PlayerUI").GetComponent<UITalk>().InteractionTalk("���Ⱑ ���� �� ����."));
        }
      
    }
}
