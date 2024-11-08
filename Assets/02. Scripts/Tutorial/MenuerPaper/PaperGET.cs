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

        truePaper.SetActive(false); //메뉴얼 이 페이지 해금

        tmenuerGetText.getSetPaperNumber = pageNumber; //페이지 넘버 T메뉴얼획득 텍스트 넘버링 보넴

        audioSource.PlayOneShot(PaperSFX);
        Invoke("Deactivate", PaperSFX.length);

    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
