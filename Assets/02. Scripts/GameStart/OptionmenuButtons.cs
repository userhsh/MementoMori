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
        button.onClick.AddListener(Back);  // 1번째 버튼 눌렀을 때 함수호출
    }

    void Back()
    {
        Mainmenu.SetActive(true);   // 메인메뉴 활성화
        Optionmenu.SetActive(false);    //옵션메뉴 비활성화
    }
}
