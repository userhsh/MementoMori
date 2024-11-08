using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionmenuButtons : MonoBehaviour
{
    Button button = null;
    public GameObject Mainmenu;
    public GameObject Optionmenu;

    private void Awake()
    {
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
