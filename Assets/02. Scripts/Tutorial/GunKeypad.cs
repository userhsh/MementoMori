using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GunKeypad : MonoBehaviour
{
    public string currentPassward = "1024";
    string passward = "";

    public Image passwardBar; // **** 표시 가림막
    public GameObject keypadSuccessGreen;
    public GameObject succeseImg;
    public Animator gunBoxGlass;

    public void KeyNumber(int _number)
    {
        switch (_number)
        {
            case 0:
                passward += "0";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 1:
                passward += "1";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 2:
                passward += "2";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 3:
                passward += "3";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 4:
                passward += "4";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 5:
                passward += "5";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 6:
                passward += "6";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 7:
                passward += "7";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 8:
                passward += "8";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 9:
                passward += "9";
                passwardBar.fillAmount -= 0.25f;
                break;
            case 10:
                if (currentPassward != passward)
                { //실패 시 초기화
                    passward = "";
                    passwardBar.fillAmount = 1f;
                }
                if (currentPassward == passward) 
                { //성공 시
                    succeseImg.SetActive(true);
                    keypadSuccessGreen.SetActive(true);
                    Invoke("SucceseEvent", 1f);                   

                }
                break;
            default:
                break;
        }
        if (passward.Length > 4)
        {
            passward = "";
            passwardBar.fillAmount = 1f;
        }
    }

    void SucceseEvent()
    {
        this.gameObject.SetActive(false);
        gunBoxGlass.enabled = true;
    }
}
