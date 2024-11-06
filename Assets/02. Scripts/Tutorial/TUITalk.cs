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

    string SuccessTalk = "����ض�..! \n���� �� �׾�߸� �ϴ°���!";
    string NotTalk = "�߿��Ѱ� ì�ܾ� �Ѵ�.";
    string NotAmmoTalk = "�Ѿ��� �ʿ��ϴ�..";
    string Collection0Talk = "�׸�����.. ��..";

    private void Awake()
    {


    }
    public IEnumerator OutAreaTalk() //���� ì�ܳ����� ���� ��
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
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(2f);
        UITalk.SetActive(false);
    }

    public IEnumerator DontShotTalk()
    {
        UITalk.SetActive(true);
        talk.text = "������ �򶧰� �ƴϴ�..\n������..!!";


        yield return new WaitForSeconds(2f);
        talk.text = "";
        UITalk.SetActive(false);
    }


}
