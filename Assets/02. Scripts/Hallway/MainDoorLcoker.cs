using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainDoorLcoker : MonoBehaviour
{
    // ��� ��ư ���� ���� ���� (0 ~ 3 �� ȭ��ǥ ��ư, 4 ~ 7 �Ʒ� ȭ��ǥ ��ư, 8 open ��ư)
    Button[] arrowButtons = null;
    // �ؽ�Ʈ ���� ���� ����
    TextMeshProUGUI[] passwordTexts = null;
    // ���� ���� �ٲ��� int �迭 ����
    int[] password = new int[4] { 0, 0, 0, 0 };
    // ���� ��й�ȣ ���ڿ�
    string correctPassword = "1022";
    // ���� �Էµ� ��й�ȣ ���ڿ�
    string nowPassword = string.Empty;
    // ���� Ŭ���� ����
    bool isGameclear = false;

    public UIManager uiManager = null;

    private void Awake()
    {
        MainDoorLockerInit();
    }

    // ������ �����ġ Init �޼���
    private void MainDoorLockerInit()
    {
        arrowButtons = GetComponentsInChildren<Button>();
        passwordTexts = GetComponentsInChildren<TextMeshProUGUI>();

        ButtonsInit();
    }

    // ��ư Init �޼���
    private void ButtonsInit()
    {
        // ��� ��ư�� ���ؼ�
        for (int i = 0; i < arrowButtons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(0));
                    break;
                case 1:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(1));
                    break;
                case 2:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(2));
                    break;
                case 3:
                    arrowButtons[i].onClick.AddListener(() => UpArrowButton(3));
                    break;
                case 4:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(0));
                    break;
                case 5:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(1));
                    break;
                case 6:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(2));
                    break;
                case 7:
                    arrowButtons[i].onClick.AddListener(() => DownArrowButton(3));
                    break;
                case 8:
                    arrowButtons[i].onClick.AddListener(PasswordCheck);
                    break;
            }
        }
    }

    // �� ��ư ������ �� �޼���
    // password�� �ε����� ��ư�� _value�� ���� ������ ����
    private void UpArrowButton(int _value)
    {
        // 1 ����
        password[_value]++;

        // ���� password ���� 10�̻��� �Ǹ�
        if (password[_value] >= 10)
        {
            // 10�� ���ֱ� 
            password[_value] -= 10;
        }
        // �ؽ�Ʈ�� ����
        passwordTexts[_value].text = password[_value].ToString();
    }

    // �Ʒ� ��ư ������ �� �޼���
    // password�� �ε����� ��ư�� _value�� ���� ������ ����
    private void DownArrowButton(int _value)
    {
        // 1 ����
        password[_value]--;

        // ���� password ���� 0�̸��� �Ǹ�
        if (password[_value] < 0)
        {
            password[_value] += 10;
        }
        // �ؽ�Ʈ�� ����
        passwordTexts[_value].text = password[_value].ToString();
    }

    private void PasswordCheck()
    {
        nowPassword = "";

        for (int i = 0; i < password.Length; i++)
        {
            nowPassword += password[i];
        }

        if (correctPassword == nowPassword)
        {
            isGameclear = true;
            Destroy(this.gameObject);

            ChangeEndingScene();
        }
        else
        {
            isGameclear = false;
        }
    }

    private void ChangeEndingScene()
    {
        if (!isGameclear) return;

        if (uiManager.IsAllCollection)
        {
            SceneManager.LoadScene("TrueEndingScene");
        }
        else
        {
            SceneManager.LoadScene("NomalEndingScene");
        }
    }
}