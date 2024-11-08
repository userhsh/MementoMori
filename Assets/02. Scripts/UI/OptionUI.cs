using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    Button button = null;
    public GameObject UIMenu;
    private GameObject Optionmenu;

    private void Awake()
    {
        Optionmenu = GameObject.Find("OptionMenu");

        button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(Back);  // 1��° ��ư ������ �� �Լ�ȣ��
    }

    void Back()
    {
        Optionmenu.SetActive(false);    //�ɼǸ޴� ��Ȱ��ȭ
        UIMenu.SetActive(true);   // ���θ޴� Ȱ��ȭ
    }
}
