using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionmenuButtons : MonoBehaviour
{
    Button button = null;
    private GameObject Mainmenu;
    private GameObject Optionmenu;

    private void Awake()
    {
        Mainmenu = GameObject.Find("Main menu");
        Optionmenu = GameObject.Find("Option menu");

        button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(Back);  // 1��° ��ư ������ �� �Լ�ȣ��
    }

    void Back()
    {
        Mainmenu.SetActive(true);   // ���θ޴� Ȱ��ȭ
        Optionmenu.SetActive(false);    //�ɼǸ޴� ��Ȱ��ȭ
    }
}
