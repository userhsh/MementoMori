using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mirror : MonoBehaviour, IInteractable
{
    // �ſ� �� ������ ���� ����
    MirrorStain mirrorStain = null;
    // �ſ� �� �����ϴ� �ִϸ����� ������ ���� ����
    Animator stainAnimator = null;
    // �ſ� UI ������ ���� ����
    Canvas mirrorCanvas = null;

    bool isInteractable = false;

    public MedicineFabric medicineFabric = null;

    private void Awake()
    {
        MirrorInit();
    }

    // Mirror Init �޼���
    private void MirrorInit()
    {
        mirrorCanvas = GetComponentInChildren<Canvas>();
        mirrorStain = GetComponentInChildren<MirrorStain>();
        stainAnimator = mirrorStain.gameObject.GetComponent<Animator>();

        mirrorCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PillowFabic_Medicine")
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PillowFabic_Medicine")
        {
            isInteractable = false;
        }
    }

    public void Interact()
    {
        if (!isInteractable) return;

        // �ſ� �� ���� �ڷ�ƾ ����
        StartCoroutine(RemoveStain());
    }

    IEnumerator RemoveStain()
    {
        // �� ���� �ִϸ��̼� ����
        stainAnimator.SetTrigger("IsRemoveStain");
        // �� ���� õ ����
        Destroy(medicineFabric);
        // �ִϸ��̼� ��� �ð� ����
        yield return new WaitForSeconds(1f);
        // �ſ� ĵ���� �ѱ�
        mirrorCanvas.gameObject.SetActive(true);
    }
}