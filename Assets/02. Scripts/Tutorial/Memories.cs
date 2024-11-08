using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip collectionSound;
    private SpriteRenderer spriteRenderer;
    private Collider collider;

    public TMenuerGetText tmenuerGetText;
    public int pageNumber;
    public GameObject getPaperUI;
    public GameObject menuerEscButton;
    public GameObject truePaper;

    private AudioClip PaperSFX;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //collectionSound = Resources.Load<AudioClip>("TutorialSFX/CollectionSound/collectionSound");

        PaperSFX = Resources.Load<AudioClip>("TutorialSFX/PaperSFX");
    }

    public void Collection0Get()
    {
        audioSource.PlayOneShot(PaperSFX);
        GameObject.Find("PlayerUI").GetComponent<TUIManager>().collections = true;
        spriteRenderer.enabled = false;
        collider.enabled = false;
       
        StartCoroutine(Collection0GetTalk());

    }

    IEnumerator Collection0GetTalk()
    {
        yield return new WaitForSeconds(1.5f);

        GameObject.Find("Left Controller").GetComponent<TLeftController>().enabled = false;
        GameObject.Find("Right Controller").GetComponent<TRightController>().enabled = false;

        yield return new WaitForSeconds(2f);
       
       StartCoroutine(GameObject.Find("PlayerUI").GetComponent<TUITalk>().GetCollection0Talk()); //UI��� ����

        yield return new WaitForSeconds(5f);

        GameObject.Find("Left Controller").GetComponent<TLeftController>().enabled = true;
        GameObject.Find("Right Controller").GetComponent<TRightController>().enabled = true;
        GetNumberPaper();
    }

    public void GetNumberPaper()
    {
        getPaperUI.SetActive(true);
        menuerEscButton.SetActive(true);

        truePaper.SetActive(false); //�޴��� �� ������ �ر�

        tmenuerGetText.getSetPaperNumber = pageNumber; //������ �ѹ� T�޴���ȹ�� �ؽ�Ʈ �ѹ��� ����

        audioSource.PlayOneShot(PaperSFX);
        Invoke("Deactivate", PaperSFX.length);

    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
