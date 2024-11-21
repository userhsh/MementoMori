using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ChildPalmPrint : MonoBehaviour
{
    private AudioClip collectionSound; // 수집품 획득 시 재생할 오디오 클립
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    private XRGrabInteractable grabInteractable; // XR 상호작용을 위한 컴포넌트

    private void Awake()
    {
        // 오디오 소스 컴포넌트를 가져와서 초기화
        audioSource = GetComponent<AudioSource>();
        // XRGrabInteractable 컴포넌트를 가져와서 초기화 (VR에서 상호작용 가능하게 함)
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        // 리소스 폴더에서 수집품 사운드 파일을 로드
        collectionSound = Resources.Load<AudioClip>("TutorialSFX/PaperSFX");

        // 물체를 잡았을 때 호출되는 이벤트 리스너 추가
        grabInteractable.selectEntered.AddListener(OnGrabbed);

        // 처음에는 오브젝트를 비활성화 상태로 설정
        gameObject.SetActive(false);
    }

    // 물체가 잡혔을 때 호출되는 함수
    public void OnGrabbed(SelectEnterEventArgs args)
    {
        // 수집품 획득 시, UIManager의 컬렉션 배열을 업데이트하여 버튼을 해금
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[0] = true;
        // 수집 대화 카운트 증가
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collectTalkCount++;
        // UIManager의 수집 대화 카운트 갱신
        GameObject.Find("PlayerUI").GetComponent<UIManager>().CollectGetTalkCount();

        // 오디오 소스에 수집품 사운드 설정 후 재생
        audioSource.clip = collectionSound;
        audioSource.Play();

        // 수집품 이미지와 충돌 영역을 비활성화하여 다시 상호작용이 안되도록 설정
        this.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
