using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuerObjectLauguage : MonoBehaviour
{
    public GameObject[] paperObject;
    public Sprite[] menuePaperEng;
    public Sprite[] menuePaperKor;

    public GameObject[] paperUi;
    public Sprite[] meEng;
    public Sprite[] meKor;

    public GameObject[] paperNameEng;
    public GameObject[] paperNameKor;

    public GameObject[] menufontEng;
    public GameObject[] menufontKor;

    public GameObject[] getMenuerUiObject;
    public Sprite[] getMenuerEng;
    public Sprite[] getMenuerKor;
    public GameObject[] getMenuerNameEng;
    public GameObject[] getMenuerNameKor;
    private void Awake()
    {

        if (GameObject.Find("GameManager").GetComponent<GameManager>().languageEng == true) //영어버전
        {
            GameObject.Find("Left Controller").GetComponent<TLeftController>().languageKorean = false;
            GameObject.Find("Right Controller").GetComponent<TRightController>().languageKorean = false;
            GameObject.Find("Left Controller").GetComponent<TLeftController>().languageEnglish = true;
            GameObject.Find("Right Controller").GetComponent<TRightController>().languageEnglish = true;


            for (int i = 0; i < menuePaperEng.Length; i++) //메뉴얼오브젝트 영어화
            {
                paperObject[i].GetComponent<SpriteRenderer>().sprite = menuePaperEng[i];
            }

            for (int i = 0; i < paperUi.Length; i++) //메뉴얼UI 영어화
            {
                paperUi[i].GetComponent<Image>().sprite = meEng[i];
                paperNameKor[i].SetActive(false);
                paperNameEng[i].SetActive(true);
            }

            for (int i = 0; i < menufontEng.Length; i++)
            {
                menufontKor[i].SetActive(false);
                menufontEng[i].SetActive(true);
            }

            for (int i = 0; i < getMenuerUiObject.Length; i++)
            {
                getMenuerUiObject[i].GetComponent<Image>().sprite = getMenuerEng[i];
                getMenuerNameKor[i].SetActive(false);
                getMenuerNameEng[i].SetActive(true);
            }

        }
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().languageKor == true) //한국어버전
        {
            GameObject.Find("Left Controller").GetComponent<TLeftController>().languageEnglish = false;
            GameObject.Find("Right Controller").GetComponent<TRightController>().languageEnglish = false;
            GameObject.Find("Left Controller").GetComponent<TLeftController>().languageKorean = true; 
            GameObject.Find("Right Controller").GetComponent<TRightController>().languageKorean = true;

            for (int i = 0; i < menuePaperKor.Length; i++) //메뉴얼오브젝트 한글화
            {
                paperObject[i].GetComponent<SpriteRenderer>().sprite = menuePaperKor[i];
            }

            for (int i = 0; i < paperUi.Length; i++) //메뉴얼UI 한글화
            {
                paperUi[i].GetComponent<Image>().sprite = meKor[i];
                paperNameEng[i].SetActive(false);
                paperNameKor[i].SetActive(true);
            }

            for (int i = 0; i < menufontKor.Length; i++)
            {
                menufontEng[i].SetActive(false);
                menufontKor[i].SetActive(true);
            }

            for (int i = 0; i < getMenuerUiObject.Length; i++)
            {
                getMenuerUiObject[i].GetComponent<Image>().sprite = getMenuerKor[i];
                getMenuerNameEng[i].SetActive(false);
                getMenuerNameKor[i].SetActive(true);
            }
        }
    }
}
