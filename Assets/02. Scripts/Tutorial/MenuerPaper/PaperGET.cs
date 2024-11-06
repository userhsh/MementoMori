using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperGET : MonoBehaviour
{
   public TMenuerGetText tmenuerGetText;
    public GameObject truePaper;
    public int pageNumber;
    public GameObject getPaperUI;
    public GameObject menuerEscButton;
    private AudioSource audioSource;
    private AudioClip PaperSFX;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PaperSFX = Resources.Load<AudioClip>("TutorialSFX/PaperSFX");
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
