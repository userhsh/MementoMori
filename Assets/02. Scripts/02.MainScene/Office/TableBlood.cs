using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBlood : MonoBehaviour, IInteractable
{

    PaperName paperName = null; //이름 적힐 종이
    SpriteRenderer nameElie = null; //이름
    Collider otherCollider = null;
    bool isTrue = false;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;
    private AudioClip PaperSFX;
    private AudioClip PencilSFX;
    private AudioClip collectionSound;
    private Collider collider;

    public GameObject pencil;

    bool isPencilInteractable = false;

    public Collider bloodCollider = null;

    private void Awake()
    {
        paperName = GetComponentInChildren<PaperName>();
        nameElie = GetComponentInChildren<SpriteRenderer>();
        nameElie.enabled = false; //이름 먼저 가져와서 꺼둔 후에
        paperName.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        PaperSFX = Resources.Load<AudioClip>("OfficeSFX/PaperSFX");
        PencilSFX = Resources.Load<AudioClip>("OfficeSFX/PencilSFX");
        collectionSound = Resources.Load<AudioClip>("TutorialSFX/PaperSFX");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Paper_None")
        {
            Destroy(other?.gameObject); //빈 종이 삭제
            bloodCollider.gameObject.SetActive(false);
            paperName.gameObject.SetActive(true); //이름 종이 출현
            audioSource.PlayOneShot(PaperSFX);
        }

        if (paperName.gameObject.activeSelf && other.gameObject.name == "Pencil")
        {
            isPencilInteractable = true;
        }

        if (other.gameObject.layer == 1 >> 10) return;

        otherCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pencil")
        {
            isPencilInteractable = false;
        }

        otherCollider = null;
    }

    public void Interact() //상호작용
    {
        if (!isPencilInteractable) return; //연필 아이템이 아닐 시 반환

        isTrue = true; 
        Destroy(otherCollider?.gameObject); //연필 아이템 삭제
        nameElie.enabled = true; //이름이미지 출현
        this.gameObject.name = "Collection2"; //콜렉션2로 이름이 바뀜
        StartCoroutine(PlayPencilSound());
    }

    public void Collection2Get()
    {
        if (isTrue)
        {
            GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[1] = true;
            GameObject.Find("PlayerUI").GetComponent<UIManager>().collectTalkCount++;
            GameObject.Find("PlayerUI").GetComponent<UIManager>().CollectGetTalkCount();

            meshRenderer.enabled = false;
            collider.enabled = false;
            paperName.gameObject.SetActive(false);
            audioSource.PlayOneShot(collectionSound);
        }
    }

    private IEnumerator PlayPencilSound()
    {
        audioSource.PlayOneShot(PencilSFX);
        Destroy(pencil.gameObject);
        yield return new WaitForSeconds(1f);
        audioSource.Stop();
    }
}