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
        button.onClick.AddListener(Back);  // 1번째 버튼 눌렀을 때 함수호출
    }

    void Back()
    {
        contentValue.anchoredPosition = new Vector3(0, 0, 0);
        Mainmenu.SetActive(true);   // 메인메뉴 활성화
        Creditmenu.SetActive(false);    //옵션메뉴 비활성화
    }
}
