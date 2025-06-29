using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager; // GameManager 변수 선언

    //메뉴창에 있는 기능
    public GameObject UIMenu;
    public GameObject UIMenuerPaper;
    public GameObject OptionMenu;
    public GameObject optionButton;
    public GameObject exitButton;

    //수집품에 있는 기능
    public bool[] collections = new bool[4];
    public GameObject[] collectionButtonLocks;
    public GameObject[] collectionButtons;
    public GameObject collectionLockImg;
    public GameObject[] collectionImgs;

    public LeftController leftController;

    public GameObject sliderRotate;
    private GameObject gamemanager;

    public UITalk uITalk;
    public int collectTalkCount = 0;

    private bool isAllCollection = false;
    public bool IsAllCollection { get { return isAllCollection; } }

    int collectionCount = 0;

    private void Awake()
    {
        for (int i = 0; i < collections.Length; i++)
        {
            collections[i] = false;
        }

        gamemanager = GameObject.Find("GameManager"); //게임메니저의 회전 슬라이드값이 필요하여 따로 선언
        sliderRotate.GetComponent<Slider>().value = gamemanager.GetComponent<GameManager>().rotateValue / 100f;
        GameObject.Find("Player").GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed = gamemanager.GetComponent<GameManager>().rotateValue;

    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
         
        }


    }

    private void Update()
    {
        // 수집품 획득 시 수집품UI의 버튼 해금
        for (int i = 0; i < collections.Length; i++)
        {
            if (collections[i] == true)
            {
                collectionButtonLocks[i].gameObject.SetActive(false);
                collectionButtons[i].gameObject.SetActive(true);
            }
        }

        CheckCollection();
    }

    public void ReturnButton() //돌아가기 버튼 누를 시 메뉴 닫음
    {
        UIMenu.SetActive(false);
    }
    public void MenuerButton() //메뉴얼 버튼 누를 시 조작관련 UI 생성
    {
        UIMenuerPaper.SetActive(true);
        UIMenu.SetActive(false);

    }

    public void OptionButton()
    {
        UIMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }
    public void ExitButton()
    {
        leftController.RemoveEvent();

        if (gameManager != null)
        {
            // Exit 버튼을 클릭했을 때 수행할 작업
            PlayerController playerController = FindObjectOfType<PlayerController>(); // 현재 씬에서 플레이어 객체를 찾음
            if (playerController != null)
            {
                // 플레이어의 위치와 회전값을 저장
                Vector3 playerPosition = playerController.transform.position; // 플레이어 위치
                Vector3 playerRotation = playerController.transform.rotation.eulerAngles; // 플레이어 회전값

                gameManager.SaveGameData(playerPosition, playerRotation); // 플레이어 위치와 회전값 저장
            }
            else
            {
             
            }
        }
        else
        {
           
        }

        SceneManager.LoadScene("GameStartScene"); // 첫 번째 씬으로 전환
    }

    public void CollectionOpen(int _collectionNumber)
    {
        for (int i = 0; i < collectionImgs.Length; i++)
        {
            collectionImgs[i].gameObject.SetActive(false);
        }
        if (_collectionNumber >= 0 && _collectionNumber < collectionImgs.Length)
        {
            collectionLockImg.gameObject.SetActive(false);
            collectionImgs[_collectionNumber].gameObject.SetActive(true);
        }
    }


    private void CheckCollection()
    {
        collectionCount = 0;

        for (int i = 0; i < collections.Length; i++)
        {
            if (collections[i])
            {
                collectionCount++;
            }
        }

        if (collectionCount >= 4)
        {
            isAllCollection = true;
        }
    }
    public IEnumerator CollectGetTalkCountColltin()
    {

        yield return new WaitForSeconds(3f);

        GameObject.Find("Left Controller").GetComponent<LeftController>().enabled = false;
        GameObject.Find("Right Controller").GetComponent<RightController>().enabled = false;

        switch (collectTalkCount)
        {
            case 1:
                if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
                {
                    StartCoroutine(uITalk.InteractionTalk("Why am I\nin this place."));
                }
                else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
                {
                     StartCoroutine(uITalk.InteractionTalk("'내'가 왜 이런 곳에\n있는 걸까."));
                }
             
                break;
            case 2:
                if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
                {
                    StartCoroutine(uITalk.InteractionTalk("A face that I will never\nforget came to mind."));
                }
                else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
                {
                    StartCoroutine(uITalk.InteractionTalk("결코 잊을 수 없는\n얼굴이 떠올랐다."));
                }
                
                break;
            case 3:
                if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
                {
                    StartCoroutine(uITalk.InteractionTalk("A child's face that meant\nmore to me than anyone else"));
                }
                else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
                {
                   StartCoroutine(uITalk.InteractionTalk("내게 그 누구보다 의미 있는\n존재였던 아이의 얼굴."));
                }
                
                break;
            case 4:
                if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish == true)
                {
                    StartCoroutine(uITalk.InteractionTalk("I was unlucky. If only \nI had cared a little more..."));
                }
                else if (GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean == true)
                {
                   StartCoroutine(uITalk.InteractionTalk("운이 나빴다. \n조금만 더 신경 썼더라면..."));
                }
               
                break;
        }

        yield break;
    }
    public void CollectGetTalkCount()
    {

        StartCoroutine(CollectGetTalkCountColltin());



    }


}
