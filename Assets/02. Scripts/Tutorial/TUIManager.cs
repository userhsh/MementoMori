using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class TUIManager : MonoBehaviour
{
    //메뉴창에 있는 기능
    public GameObject UIMenu;
    public GameObject UIMenuerPaper;
    public GameObject OptionMenu;
    public GameObject optionButton;
    public GameObject exitButton;

    //수집품에 있는 기능
    public bool collections = false;

    public GameObject collectionButtonLocks;
    public GameObject collectionButtons;
    public GameObject collectionLockImg;
    public GameObject collectionImg;

    public TLeftController TleftController;

    private GameObject gameManager;
    public GameObject sliderRotate;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        sliderRotate.GetComponent<Slider>().value = gameManager.GetComponent<GameManager>().rotateValue / 100f;
        GameObject.Find("Player").GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed = gameManager.GetComponent<GameManager>().rotateValue;
    }

    private void Update()
    {
        //수집품 획득 시 수집품UI의 버튼 해금
        if (collections == true)
        {
            collectionButtonLocks.gameObject.SetActive(false);
            collectionButtons.gameObject.SetActive(true);
        }

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
        TleftController.RemoveEvent();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameStartScene");
    }

    public void CollectionOpen(int _collectionNuber)
    {

        if (_collectionNuber == 0)
        {   
           
            collectionLockImg.gameObject.SetActive(false);
            collectionImg.gameObject.SetActive(true);
        }



    }
}


