using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TUITalk : MonoBehaviour
{
    public GameObject UITalk;
    public Text talk;

    public GameObject fadeOut;

    string SuccessTalk = "기억해라..! \n결코 넌 죽어야만 하는것을!";
    string NotTalk = "중요한걸 챙겨야 한다.";
    string NotAmmoTalk = "총알이 필요하다..";
    string dontShot = "아직은 쏠때가 아니다..";

    private void Awake()
    {


    }
    public IEnumerator OutAreaTalk() //총을 챙겨나오고 성공 시
    {
        UITalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < SuccessTalk.Length; i++)
        {
            talk.text += SuccessTalk[i];
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);
        UITalk.SetActive(false);
        fadeOut.SetActive(true);
      //  GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
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

    public IEnumerator DontShotTalk()
    {
        UITalk.SetActive(true);
        talk.text = "아직은 쏠때가 아니다..";


        yield return new WaitForSeconds(2f);
        talk.text = "";
        UITalk.SetActive(false);
    }
}
