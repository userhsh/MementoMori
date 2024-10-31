using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class TUIManager : MonoBehaviour
{
    //�޴�â�� �ִ� ���
    public GameObject UIMenu;
    public GameObject OptionMenu;
    public GameObject optionButton;
    public GameObject exitButton;

    //����ǰ�� �ִ� ���
    public bool collections = false;

    public GameObject collectionButtonLocks;
    public GameObject collectionButtons;
    public GameObject collectionLockImg;
    public GameObject collectionImg;

    public TLeftController TleftController;

    private void Awake()
    {

    }

    private void Update()
    {
        //����ǰ ȹ�� �� ����ǰUI�� ��ư �ر�
        if (collections == true)
        {
            collectionButtonLocks.gameObject.SetActive(false);
            collectionButtons.gameObject.SetActive(true);
        }

    }

    public void ReturnButton() //���ư��� ��ư ���� �� �޴� ����
    {
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


