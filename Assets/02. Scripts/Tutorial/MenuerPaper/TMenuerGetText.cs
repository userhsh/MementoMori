using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TMenuerGetText : MonoBehaviour
{
    public GameObject[] Papers;

    public Text GetText;
    public GameObject getTextBox;
    public GameObject menuerEscButton;

    public int getSetPaperNumber = 0;

    string paperGetTalk = "";

    public IEnumerator PaperGetTalk(int paperNum)
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().languageEng == true)
        {
            paperGetTalk = $"≡Menu - Controll Menuer\n{paperNum + 1} / 7 page";
        }
        if (GameObject.Find("GameManager").GetComponent<GameManager>().languageKor == true)
        {
           paperGetTalk = $"≡메뉴 - 조작 메뉴얼\n{paperNum + 1} / 7 page";
        }


        getTextBox.SetActive(true);
        GetText.text = "";
        for (int i = 0; i < paperGetTalk.Length; i++)
        {
            GetText.text += paperGetTalk[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(4f);
        getTextBox.SetActive(false);

        yield break;
    }

    public void CloseButtonEvent()
    {

        for (int i = 0; i < Papers.Length; i++)
        {
            Papers[i].gameObject.SetActive(false);
        }
        menuerEscButton.SetActive(false);

        StartCoroutine(PaperGetTalk(getSetPaperNumber)); //메뉴얼 경로를 설명하는 텍스트
    }
}
