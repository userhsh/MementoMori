using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditCloseButtons : MonoBehaviour
{
    Button button = null;
    public GameObject Mainmenu;
    public GameObject Creditmenu;

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
        Creditmenu.SetActive(false);    //�ɼǸ޴� ��Ȱ��ȭ
    }
}
