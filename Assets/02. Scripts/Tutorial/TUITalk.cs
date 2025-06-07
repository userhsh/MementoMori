using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TUITalk : MonoBehaviour
{
    public GameObject UITalk;
    public GameObject UINextTalk;
    public Text talk;
    public Text Nexttalk;

    public GameObject fadeOut;

    string SuccessTalk = "기억해라..! \n결국 넌 죽어야만 하는것을!";
    string NotTalk = "중요한걸 챙겨야 한다.";
    string NotAmmoTalk = "총알이 필요하다..";
    string Collection0Talk = "그립구나.. 딸..";

    private void Awake()
    {

        if (GameObject.Find("GameManager").GetComponent<GameManager>().languageEng == true)
        {
            SuccessTalk = "Remember..!\nIn the end, you must die!";
            NotTalk = "I have to pack \nimportant things.";
            NotAmmoTalk = "I need a bullet..";
            Collection0Talk = "I miss you, \nmy daughter..";
        }
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().languageKor == true)
        {
            SuccessTalk = "기억해라..! \n결국 넌 죽어야만 하는것을!";
            NotTalk = "중요한걸 챙겨야 한다.";
            NotAmmoTalk = "총알이 필요하다..";
            Collection0Talk = "그립구나.. 딸..";
        }
    }
    public IEnumerator OutAreaTalk() //총을 챙겨나오고 성공 시
    {
        UINextTalk.SetActive(true);
        Nexttalk.text = "";
        for (int i = 0; i < SuccessTalk.Length; i++)
        {
            Nexttalk.text += SuccessTalk[i];
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);
        UINextTalk.SetActive(false);
        fadeOut.SetActive(true);
        GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
        yield break;
    }

    public IEnumerator NotOutAreaTalk()
    {
        UITalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < NotTalk.Length; i++)
        {
            talk.text += NotTalk[i];
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);
        UITalk.SetActive(false);
    }

    public IEnumerator NotAmmoOutAreaTalk()
    {
        UITalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < NotAmmoTalk.Length; i++)
        {
            talk.text += NotAmmoTalk[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        UITalk.SetActive(false);
    }

    public IEnumerator GetCollection0Talk()
    {
        UITalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < Collection0Talk.Length; i++)
        {
            talk.text += Collection0Talk[i];
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(2f);
        UITalk.SetActive(false);
    }

    public IEnumerator DontShotTalk()
    {
        UITalk.SetActive(true);
        if (GameObject.Find("GameManager").GetComponent<GameManager>().languageEng == true)
        {
            talk.text = "It's not time to shoot..\nLet's get out..!";
        }
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().languageKor == true)
        {
            talk.text = "아직은 쏠때가 아니다..\n나가자..!!";
        }



        yield return new WaitForSeconds(2f);
        talk.text = "";
        UITalk.SetActive(false);
    }

    IEnumerator GunPasswardTalk()
    {
        UITalk.SetActive(true);
        if (GameObject.Find("GameManager").GetComponent<GameManager>().languageEng == true)
        {
            talk.text = "There is important \ninformation here";
        }
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().languageKor == true)
        {
            talk.text = "중요한 정보가 있다";
        }
        yield return new WaitForSeconds(2f);
        talk.text = "";
        UITalk.SetActive(false);
    }

    public void StartGunPasswardTalk()
    {
        StartCoroutine(GunPasswardTalk());
    }
}
