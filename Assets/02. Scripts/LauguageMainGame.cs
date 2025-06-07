using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LauguageMainGame : MonoBehaviour
{
    public bool languageEnglish = false;
    public bool languageKorean = false;

    public GameObject[] setActiveObjectEng;
    public GameObject[] setActiveObjectKor;

    public GameObject[] imgObject;
    public Sprite[] engSprites;
    public Sprite[] korSprites;

    private void Awake()
    {
        languageEnglish = GameObject.Find("GameManager").GetComponent<GameManager>().languageEng;
        languageKorean = GameObject.Find("GameManager").GetComponent<GameManager>().languageKor;


        if (languageEnglish) //영어적용 시
        {  
            GameObject.Find("Left Controller").GetComponent<LeftController>().languageKorean = false;
            GameObject.Find("Right Controller").GetComponent<RightController>().languageKorean = false;
            GameObject.Find("Left Controller").GetComponent<LeftController>().languageEnglish = true;
            GameObject.Find("Right Controller").GetComponent<RightController>().languageEnglish = true;
          
            for (int i = 0; i < setActiveObjectEng.Length; i++)
            {
                setActiveObjectKor[i].SetActive(false);
                setActiveObjectEng[i].SetActive(true);
            }

            for (int i = 0; i < imgObject.Length; i++)
            {
                imgObject[i].GetComponent<Image>().sprite = engSprites[i];
            }
        }
        else if (languageKorean)
        {
            GameObject.Find("Left Controller").GetComponent<LeftController>().languageEnglish = false;
            GameObject.Find("Right Controller").GetComponent<RightController>().languageEnglish = false;
            GameObject.Find("Left Controller").GetComponent<LeftController>().languageKorean = true;
            GameObject.Find("Right Controller").GetComponent<RightController>().languageKorean = true;

            for (int i = 0; i < setActiveObjectKor.Length; i++)
            {
                setActiveObjectEng[i].SetActive(false);
                setActiveObjectKor[i].SetActive(true);
            }

            for (int i = 0; i < imgObject.Length; i++)
            {
                imgObject[i].GetComponent<Image>().sprite = korSprites[i];
            }
        }
    }


}
