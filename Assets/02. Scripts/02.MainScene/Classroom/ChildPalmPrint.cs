using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
        collectionSound = Resources.Load<AudioClip>("TutorialSFX/PaperSFX");

        //��ü�� ���� �� ȣ��Ǵ� �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(OnGrabbed);

        gameObject.SetActive(false);
    }


    // ��ü�� ������ �� ȣ��Ǵ� �Լ�
   public void OnGrabbed(SelectEnterEventArgs args)
    {
        //����ǰ ȹ�� �� ����ǰUI�� ��ư �ر�
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[0] = true;
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collectTalkCount++;
        GameObject.Find("PlayerUI").GetComponent<UIManager>().CollectGetTalkCount();

        audioSource.clip = collectionSound;
        audioSource.Play();

        this.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        Destroy(this.gameObject, collectionSound.length);
    }
}
