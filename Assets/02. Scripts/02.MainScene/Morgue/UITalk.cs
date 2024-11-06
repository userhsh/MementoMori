using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UITalk : MonoBehaviour
{
    public GameObject uiTalk;
    public Text talk;

    string talk1 = "���� �����..?!";
    string talk2 = "�ƹ��͵� ��ﳪ�� �ʴ´�..";

    private void Start()
    {
        Invoke("StartTalkCount", 10f);
    }

    void StartTalkCount()
    {
        StartCoroutine(StartTalk());
    }

    public IEnumerator StartTalk() //���� ì�ܳ����� ���� ��
    {
        uiTalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < talk1.Length; i++)
        {
            talk.text += talk1[i];
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);

        talk.text = "";
        for (int i = 0; i < talk2.Length; i++)
        {
            talk.text += talk2[i];
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);
        uiTalk.SetActive(false);

        yield break;
    }

}
