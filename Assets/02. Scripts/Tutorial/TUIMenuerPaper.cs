using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class TUIMenuerPaper : MonoBehaviour
{
    public GameObject menuerClose;
    public GameObject[] Pages;
    int pageNum = 0;
    private void Start() //시작할때 조작메뉴얼 셋팅
    {
        for (int i = 0; i < Pages.Length; i++)
        {
            Pages[i].SetActive(false);
        }

        Pages[pageNum].SetActive(true);
    }

    public void BeforePage()
    {
        for (int i = 0; i < Pages.Length; i++)
        {
            Pages[i].SetActive(false);
        }

        pageNum--;

        if (pageNum < 0)
        {
            pageNum = 6;
        }

        Pages[pageNum].SetActive(true);
    }
    public void NextPage()
    {
        for (int i = 0; i < Pages.Length; i++)
        {
            Pages[i].SetActive(false);
        }

        pageNum++;

        if (pageNum > 6)
        {
            pageNum = 0;
        }
        Pages[pageNum].SetActive(true);
    }

    public void MenuerClose()
    {
        menuerClose.SetActive(false);
    }
}
