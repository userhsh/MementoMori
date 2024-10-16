using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
            // ������ ��ư�̶��
            if (i == arrowButtons.Length - 1)
            {
                // PasswordCheck �޼��� ����
                arrowButtons[i].onClick.AddListener(PasswordCheck);
            }
            // �ε��� 0 ~ 3 �� ��ư�̶��
            else if (i < 4)
            {
                // UpArrowButton �޼��� ����, _value�� i (= 0, 1, 2, 3)
                arrowButtons[i].onClick.AddListener(() => UpArrowButton(i));
            }
            // �ε��� 4 ~ 7 �� ��ư�̶��
            else
            {
                // DownArrowButton �޼��� ����, _value�� i % 4 (= 0, 1, 2, 3)
                arrowButtons[i].onClick.AddListener(() => DownArrowButton(i % 4));
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
        foreach (int i in password)
        {
            nowPassword += i.ToString();
        }

        if (correctPassword == nowPassword)
        {
            isGameclear = true;
        }
    }
}