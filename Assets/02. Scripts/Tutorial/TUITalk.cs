using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TUITalk : MonoBehaviour
{
    public GameObject UITalk;
    public Text talk;

    public GameObject fadeOut;

    string SuccessTalk = "����ض�..! \n���� �� �׾�߸� �ϴ°���!";
    string NotTalk = "�߿��Ѱ� ì�ܾ� �Ѵ�.";
    string NotAmmoTalk = "�Ѿ��� �ʿ��ϴ�..";

    private void Awake()
    {
        
      
    }
   public IEnumerator OutAreaTalk() //���� ì�ܳ����� ���� ��
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
        yield break;
    }

    public IEnumerator NotOutAreaTalk()
    {
        UITalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < NotTalk.Length; i++)
        {
            talk.text += NotTalk[i];
            yield return new WaitForSeconds(0.1f);
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

}