using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuButtons : MonoBehaviour
{
    Button[] buttons = null;
    private GameObject Mainmenu;
    private GameObject Optionmenu;


    private void Awake()
    {
        Mainmenu = GameObject.Find("Main menu");
        Optionmenu = GameObject.Find("Option menu");

        buttons = GetComponentsInChildren<Button>();    // ��ư�� �迭��
    }

    private void Start()
    {
        Optionmenu.gameObject.SetActive(false);

        buttons[0].onClick.AddListener(Continue);  // 1��° ��ư ������ �� �Լ�ȣ��
        buttons[1].onClick.AddListener(ChangeMorgueScene);  // 2��° ��ư ������ �� �Լ�ȣ��
        buttons[2].onClick.AddListener(EnterOption);  // 3��° ��ư ������ �� �Լ�ȣ��
        buttons[3].onClick.AddListener(GameExit);   // 4��° ��ư ������ �� �Լ�ȣ��
    }

    void Continue()
    {
        Debug.Log("����� �κ����� �� �̵�");
    }

    void ChangeMorgueScene()    
    {
        SceneManager.LoadScene("LoadingScene");  // �ε��� �ε�
    }

    void EnterOption()
    {
        Mainmenu.SetActive(false);  // ���θ޴� ��Ȱ��ȭ
        Optionmenu.SetActive(true); // �ɼǸ޴� Ȱ��ȭ
    }

    void GameExit()
    {
        #if UNITY_EDITOR    // ����Ƽ �������� �� ���� ���
            UnityEditor.EditorApplication.isPlaying = false;
        #else   // �� �� ���ø����̼��� �� ��������
            Application.Quit();
        #endif
    }
}