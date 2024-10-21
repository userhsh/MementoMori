using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChildPalmPrint : MonoBehaviour
{
    private AudioClip collectionSound;
    private AudioSource audioSource;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        // XRGrabInteractable ������Ʈ�� ������
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        collectionSound = Resources.Load<AudioClip>("CollectionSound/collectionSound");

        //��ü�� ���� �� ȣ��Ǵ� �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(OnGrabbed);

        gameObject.SetActive(false);
    }


    // ��ü�� ������ �� ȣ��Ǵ� �Լ�
   public void OnGrabbed(SelectEnterEventArgs args)
    {
        //����ǰ ȹ�� �� ����ǰUI�� ��ư �ر�
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[0] = true;

        audioSource.clip = collectionSound;
        audioSource.Play();

        this.gameObject.SetActive(false);
    }
}
