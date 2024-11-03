using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GunKeypad : MonoBehaviour
{
    private AudioSource audiosource;
    private AudioClip ClickSound;
    private AudioClip CorrectSound;
    private AudioClip BlipSound;
    private AudioClip GlassSound;
    private Canvas canvas;
    private string passward = "";

    public string currentPassward = "1024";
    public Image passwardBar; // **** 표시 가림막
    public GameObject keypadSuccessGreen;
    public GameObject succeseImg;
    public Animator gunBoxGlass;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        ClickSound = Resources.Load<AudioClip>("TutorialSFX/ClickSound/ClickSound");
        CorrectSound = Resources.Load<AudioClip>("TutorialSFX/ClickSound/CorrectSound");
        BlipSound = Resources.Load<AudioClip>("TutorialSFX/ClickSound/BlipSound");
        GlassSound = Resources.Load<AudioClip>("TutorialSFX/GlassSound/GlassSound");
    }

    public void KeyNumber(int _number)
    {
        switch (_number)
        {
            case 0:
                passward += "0";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 1:
                passward += "1";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 2:
                passward += "2";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 3:
                passward += "3";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 4:
                passward += "4";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 5:
                passward += "5";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 6:
                passward += "6";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 7:
                passward += "7";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 8:
                passward += "8";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 9:
                passward += "9";
                passwardBar.fillAmount -= 0.25f;
                audiosource.PlayOneShot(ClickSound);
                break;
            case 10:
                if (currentPassward != passward)
                { //실패 시 초기화
                    passward = "";
                    passwardBar.fillAmount = 1f;
                    audiosource.PlayOneShot(BlipSound);
                }
                if (currentPassward == passward)
                { //성공 시
                    succeseImg.SetActive(true);
                    keypadSuccessGreen.SetActive(true);
                    Invoke("SucceseEvent", 1f);
                    audiosource.PlayOneShot(CorrectSound);
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
        canvas.enabled = false;
        gunBoxGlass.enabled = true;
        audiosource.PlayOneShot(GlassSound);
    }
}
