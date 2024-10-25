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
        button.onClick.AddListener(Back);  // 1번째 버튼 눌렀을 때 함수호출
    }

    void Back()
    {
        Optionmenu.SetActive(false);    //옵션메뉴 비활성화
        UIMenu.SetActive(true);   // 메인메뉴 활성화
    }
}
