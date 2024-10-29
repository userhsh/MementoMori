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
        // XRGrabInteractable 컴포넌트를 가져옴
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        collectionSound = Resources.Load<AudioClip>("CollectionSound/collectionSound");

        //물체를 잡을 때 호출되는 이벤트 연결
        grabInteractable.selectEntered.AddListener(OnGrabbed);

        gameObject.SetActive(false);
    }


    // 물체가 잡혔을 때 호출되는 함수
   public void OnGrabbed(SelectEnterEventArgs args)
    {
        //수집품 획득 시 수집품UI의 버튼 해금
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[0] = true;

        audioSource.clip = collectionSound;
        audioSource.Play();

        this.gameObject.SetActive(false);
    }
}
