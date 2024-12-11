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
    public GameObject strangeTileEffect;
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
        // GameManager �̱��� �ν��Ͻ� ��������
        gameManager = GameManager.GetInstance();
        crawbarSound = Resources.Load<AudioClip>("MorgueSFX/CrawbarSound/crawbarSound");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "StrangeTile")
        {
            use = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.name == "StrangeTile")
        {
            use = false;
        }
    }

 

    public void Use()
    {
        if (use == true)
        {
            print("ũ�ο�� ���");
            strangeTile.gameObject.SetActive(false);
            audioSource.PlayOneShot(crawbarSound);
            childmeshRenderer.enabled = false;
            collider.enabled = false;
            switchButton.GetComponent<BoxCollider>().enabled = true;
            strangeTileEffect.SetActive(true); // �̻���Ÿ�� ���ٶ� ����Ʈ
            gameManager.crowbarActive = false; // GameManager�� crowbarActive ���� ������Ʈ
            gameManager.SaveGameData(transform.position, transform.rotation.eulerAngles); // ������ ����
        }
    }
}
