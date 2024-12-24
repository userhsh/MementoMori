using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditCloseButtons : MonoBehaviour
{
    Button button = null;
    public RectTransform contentValue;
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
        contentValue.anchoredPosition = new Vector3(0, 0, 0);
        Mainmenu.SetActive(true);   // ���θ޴� Ȱ��ȭ
        Creditmenu.SetActive(false);    //�ɼǸ޴� ��Ȱ��ȭ
    }
}
