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

    string talk1 = "���� �����..?!";
    string talk2 = "�ƹ��͵� ��ﳪ�� �ʴ´�..";

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
            talk1 = "���� �����..?!";
            talk2 = "�ƹ��͵� ��ﳪ�� �ʴ´�..";
        }
    }

    private void Start()
    {
        StartCoroutine(StartTalk());
        leftController.SetActive(false);
        rightController.SetActive(false);
        GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0.3f;
    }

    public IEnumerator StartTalk() //������ ��
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

    public IEnumerator InteractionTalk(string _text) //��� ���� �ڷ�ƾ
    {
        if (isCoroutine) yield break;

        isCoroutine = true;
        uiTalk.SetActive(true);

        talk.text = ""; //����� �ؽ�Ʈ�� talk.text�� String���� ���忪��

        //�ݺ����� ���� talk.text���� _text�� �ŰԺ����� ���� �ؽ�Ʈ�� �ѱ��ھ� ����
        for (int i = 0; i < _text.Length; i++)
        {
            talk.text += _text[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        //��� ���� 2�� �ڿ� ����/������ ��Ʈ�ѷ� ��Ȱ�� 
        leftController.GetComponent<LeftController>().enabled = true;
        rightController.GetComponent<RightController>().enabled = true;
        
        uiTalk.SetActive(false); //uiTalkâ ��Ȱ��

        isCoroutine = false; //������ ��Ȱ��

        yield break;
    }
}
