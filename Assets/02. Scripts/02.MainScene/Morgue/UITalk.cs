using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UITalk : MonoBehaviour
{
    public GameObject uiTalk;
    public Text talk;

    string talk1 = "여긴 어디지..?!";
    string talk2 = "아무것도 기억나지 않는다..";

    private void Start()
    {
        Invoke("StartTalkCount", 10f);
    }

    void StartTalkCount()
    {
        StartCoroutine(StartTalk());
    }

    public IEnumerator StartTalk() //총을 챙겨나오고 성공 시
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
