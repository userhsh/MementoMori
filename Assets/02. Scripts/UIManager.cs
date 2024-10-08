using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    //메뉴창에 있는 기능
    public GameObject UIMenu;
    public GameObject optionButton;
    public GameObject exitButton;

    //수집품에 있는 기능
   public bool[] collections = new bool[4];

    public GameObject[] collectionButtons;
    public GameObject[] collectionImgs;

    public GameObject UICollection;

    private void Awake()
    {
        for (int i = 0; i < collections.Length; i++)
        {
            collections[i] = false;
        }
    }
    private void Update()
    {
        //수집품 획득 시 수집품UI의 버튼 해금
        if (collections[0] == true)
        {
            collectionButtons[0].gameObject.SetActive(true);
        }
       if (collections[1] == true)
        {
            collectionButtons[1].gameObject.SetActive(true);
        }
       if (collections[2] == true)
        {
            collectionButtons[2].gameObject.SetActive(true);
        }
       if (collections[3] == true)
        {
            collectionButtons[3].gameObject.SetActive(true);
        }
    }

    public void ReturnButton() //돌아가기 버튼 누를 시 메뉴 닫음
    {
        UIMenu.SetActive(false);
    }
    public void OptionButton()
    {

    }
    public void ExitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameStartScene");
    }

    public void CollectionOpen(int _collectionNuber)
    {
        for (int i = 0; i < collectionImgs.Length; i++)
        {
            collectionImgs[i].gameObject.SetActive(false);
        }
        switch (_collectionNuber)
        {
            case 0:
                collectionImgs[0].gameObject.SetActive(true);
                break;
            case 1:
                collectionImgs[1].gameObject.SetActive(true);
                break;
            case 2:
                collectionImgs[2].gameObject.SetActive(true);
                break;
            case 3:
                collectionImgs[3].gameObject.SetActive(true);
                break;
        }
    }




}
