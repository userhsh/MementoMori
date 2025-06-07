using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UITalk : MonoBehaviour
{
    GameObject leftController;
    GameObject rightController;

    public GameObject uiTalk;
    public Text talk;

    string talk1 = "여긴 어디지..?!";
    string talk2 = "아무것도 기억나지 않는다..";

    bool isCoroutine = false;

    private void Awake()
    {
        var languageEnglish = GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageEnglish;
        var languageKorean = GameObject.Find("LauguageManager").GetComponent<LauguageMainGame>().languageKorean;

        leftController = GameObject.Find("Left Controller");
        rightController = GameObject.Find("Right Controller");

        if(languageEnglish == true )
        {
            talk1 = "Where am I?";
            talk2 = "I don't remember anything..";
        }
        else if(languageKorean == true)
        {
            talk1 = "여긴 어디지..?!";
            talk2 = "아무것도 기억나지 않는다..";
        }
    }

    private void Start()
    {
        StartCoroutine(StartTalk());
        leftController.SetActive(false);
        rightController.SetActive(false);
        GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0.3f;
    }

    public IEnumerator StartTalk() //시작할 때
    {
        yield return new WaitForSeconds(7f);

        leftController.SetActive(true);
        rightController.SetActive(true);

        leftController.GetComponent<LeftController>().enabled = false;
        rightController.GetComponent<RightController>().enabled = false;
        GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 2f;

        uiTalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < talk1.Length; i++)
        {
            talk.text += talk1[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);

        talk.text = "";
        for (int i = 0; i < talk2.Length; i++)
        {
            talk.text += talk2[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        uiTalk.SetActive(false);


        leftController.GetComponent<LeftController>().enabled = true;
        rightController.GetComponent<RightController>().enabled = true;

        yield break;
    }

    public IEnumerator InteractionTalk(string _text) //대사 실행 코루틴
    {
        if (isCoroutine) yield break;

        isCoroutine = true;
        uiTalk.SetActive(true);

        talk.text = ""; //대사할 텍스트를 talk.text에 String으로 저장역할

        //반복문을 통해 talk.text에다 _text의 매게변수로 받은 텍스트를 한글자씩 생성
        for (int i = 0; i < _text.Length; i++)
        {
            talk.text += _text[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        //대사 이후 2초 뒤에 왼쪽/오른쪽 컨트롤러 재활성 
        leftController.GetComponent<LeftController>().enabled = true;
        rightController.GetComponent<RightController>().enabled = true;
        
        uiTalk.SetActive(false); //uiTalk창 비활성

        isCoroutine = false; //코투린 비활성

        yield break;
    }
}
