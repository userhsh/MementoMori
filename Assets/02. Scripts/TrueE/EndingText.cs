using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{
    string[] endingText;

    TextMeshProUGUI showEndingText = null;
    string text = string.Empty;

    int count = 0;
    float delay = 2f;

    private void Awake()
    {
        showEndingText = GetComponentInChildren<TextMeshProUGUI>();
        showEndingText.text = "";

        endingText = new string[]
        {
            "결국 여기까지 왔군.",
            "...",
            "그 애가 싫어하겠지만...",
            "난 이미 좋은 아빠가 아니라서.",
            "...",
            "...지옥에서 기다려라."
        };

    }

    private void Start()
    {
       
        StartCoroutine(ShowText());
        
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
            
            if(count == endingText.Length-1)
            {
                showEndingText.color = Color.red;
            }
        }
    }
}
