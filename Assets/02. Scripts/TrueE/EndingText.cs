using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{
    GunHit gunHit;

    string[] endingText;

    Image gunImage;
    TextMeshProUGUI showEndingText = null;
    string text = string.Empty;

    int count = 0;
    float delay = 2f;

    private void Awake()
    {
        gunHit = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<GunHit>();
        gunImage = GetComponentInChildren<Image>();
        showEndingText = GetComponentInChildren<TextMeshProUGUI>();
        showEndingText.text = "";

        //endingText = new string[]
        //{
        //    "�ᱹ ������� �Ա�.",
        //    "...",
        //    "�� �ְ� �Ⱦ��ϰ�����...",
        //    "�� �̹� ���� �ƺ��� �ƴ϶�.",
        //    "...",
        //    "...�������� ��ٷ���."
        //};        

        endingText = new string[]
        {

            "..."

        };

    }

    private void Start()
    {

        StartCoroutine(ShowText());
        //gunImage.gameObject.SetActive(true);
        //showEndingText.gameObject.SetActive(true);

    }


    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(delay);

        while (count < endingText.Length)
        {
            text = endingText[count];

            for (int i = 0; i < text.Length; i++)
            {
                showEndingText.text += text[i];
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2f);

            showEndingText.text = string.Empty;

            count++;

            if (count == endingText.Length - 1)
            {
                showEndingText.color = Color.red;
            }
        }


        StartCoroutine(gunHit.ShakeCamera());
        StartCoroutine(gunHit.ShowBloodEffect());
        StopCoroutine(ShowText());
    }
}
