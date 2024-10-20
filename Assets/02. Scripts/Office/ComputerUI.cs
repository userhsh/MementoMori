using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour
{

    AudioSource audioSource = null;
    AudioClip numberClip = null;
    AudioClip correctClip = null;
    AudioClip wrongClip = null;

    QuizWindow quizWindow = null;
    AnswerWindow answerWindow = null;

    SurgeryKey surgeryKey = null;

    Keyboard keyboard = null; //Ű���� ��ư �迭 ��Ƶ� ��ũ��Ʈ �ҷ��� ��
    TextMeshProUGUI passwordText = null; //��¿� ��й�ȣ �ؽ�Ʈ > ****
    WrongImage wrongImage = null; //���信�� ���� ������ ����� �̹���

    string password = ""; //����� �񱳿� ���� �ؽ�Ʈ
    string correctPassword = "3752"; //�н����� ����
    string quizAnswer = "3"; //���� ����

    bool isQuizOn = false; //���� â�� ���ִ��� ����

    public void ComputerUIInit()
    {
        audioSource = GetComponent<AudioSource>();
        numberClip = Resources.Load<AudioClip>("OfficeSFX/PCNumber");
        correctClip = Resources.Load<AudioClip>("OfficeSFX/Correct");
        wrongClip = Resources.Load<AudioClip>("OfficeSFX/Wrong");


        quizWindow = GetComponentInChildren<QuizWindow>();
        quizWindow.gameObject.SetActive(false);

        answerWindow = GetComponentInChildren<AnswerWindow>();
        answerWindow.gameObject.SetActive(false);

        surgeryKey = GameObject.FindObjectOfType<SurgeryKey>();
        surgeryKey.gameObject.SetActive(false);

        keyboard = GetComponentInChildren<Keyboard>();
        passwordText = GetComponentInChildren<TextMeshProUGUI>();
        wrongImage = GetComponentInChildren<WrongImage>();
        keyboard.KeyboardButtonInit();

        wrongImage.gameObject.SetActive(false); //�����̹��� ����

        GetButtonList();

    }

    private void GetNumber(string _buttonName)
    {
        if (password.Length >= 4) return; //�ִ� 4�ڸ� �����ʵ��� > ������ ����
        password += _buttonName; //�Ǻ��� ���� �Է¼��� ������
        DisplayText(); //* ���� ������Ʈ
        print(password);
    }

    private void DeletePassword() // DEL �������� 
    {
        if (password.Length > 0) // ��й�ȣ�� 0���� ũ�� ����
        {
            password = password.Substring(0, password.Length - 1);
            DisplayText();
            print(password);
        }
    }

    private void CheckPassword()
    {
        

        if (password.Length == 0) return;


        if (isQuizOn == false)
        {
            if (password == correctPassword)
            {
                print("CorrectPassword");
                audioSource.PlayOneShot(correctClip);
                quizWindow.gameObject.SetActive(true); //����ȭ�� ���
                isQuizOn = true;
                ClearPassword();

            }
            else
            {
                wrongImage.gameObject.SetActive(true);
                audioSource.PlayOneShot(wrongClip);
                Invoke("OffWrongImage", 1f);
                ClearPassword();
            }
        }
        else
        {
            if (password == quizAnswer)
            {
                print("����ȭ�� ���");
                audioSource.PlayOneShot(correctClip);
                quizWindow.gameObject.SetActive(false);
                answerWindow.gameObject.SetActive(true);
                surgeryKey.gameObject.SetActive(true);
            }
            else
            {
                print("����");
                audioSource.PlayOneShot(wrongClip);
                ClearPassword();
            }
        }
    }

    private void OffWrongImage()
    {
        wrongImage.gameObject.SetActive(false);
    }

    private void ClearPassword()
    {
        password = "";
        DisplayText();
    }

    private void DisplayText()
    {
        if (password.Length == 0)
        {
            passwordText.text = "";
        }
        else
        {
            passwordText.text = new string('*', password.Length);
        }
    }

    private void GetButtonList()
    {
        foreach (Button _button in keyboard.KeyboardButton) //�� ��ư�鸶�� Ŭ���̺�Ʈ ����
        {
            if (_button.name == "DEL")
            {
                _button.onClick.AddListener(() => DeletePassword()); //���ڸ� ����
            }
            else if (_button.name == "ENTER")
            {
                _button.onClick.AddListener(() => CheckPassword()); //��й�ȣ �Ǻ�
            }
            else
            {
                _button.onClick.AddListener(() => GetNumber(_button.name)); //�����Է� ����
                audioSource.PlayOneShot(numberClip);
            }
        }
    }
}