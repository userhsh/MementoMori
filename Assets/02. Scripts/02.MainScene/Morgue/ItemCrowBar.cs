using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemCrowBar : MonoBehaviour
{
    public bool use = false;

    public GameObject strangeTile;
    public GameObject switchButton;
    private AudioSource audioSource;
    private AudioClip crawbarSound;
    private MeshRenderer childmeshRenderer;
    private Collider collider;
    private GameManager gameManager;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        childmeshRenderer = GetComponentInChildren<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        // GameManager 싱글톤 인스턴스 가져오기
        gameManager = GameManager.GetInstance();
        crawbarSound = Resources.Load<AudioClip>("CrawbarSound/crawbarSound");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "StrangeTile")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "StrangeTile")
        {
            use = false;
        }
    }

    public void Use()
    {
        if (use == true)
        {
            print("크로우바 사용");
            strangeTile.gameObject.SetActive(false);
            audioSource.PlayOneShot(crawbarSound);
            childmeshRenderer.enabled = false;
            collider.enabled = false;
            switchButton.GetComponent<BoxCollider>().enabled = true;

            gameManager.crowbarActive = false; // GameManager의 crowbarActive 상태 업데이트
            gameManager.SaveGameData(transform.position, transform.rotation.eulerAngles); // 데이터 저장
        }
    }
}
