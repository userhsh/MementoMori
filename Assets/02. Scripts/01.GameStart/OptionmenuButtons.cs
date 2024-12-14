using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OptionmenuButtons : MonoBehaviour
{
    Button button = null;
    public GameObject Mainmenu;
    public GameObject Optionmenu;
    private GameObject gameManager;
    private GameObject sliderRotate;

    private void Awake()
    {
        button = GetComponentInChildren<Button>();

        gameManager = GameObject.Find("GameManager");
        sliderRotate = GameObject.Find("Slider Rotate");
        sliderRotate.GetComponent<Slider>().value = gameManager.GetComponent<GameManager>().rotateValue / 100f;
    }

    private void Start()
    {
        button.onClick.AddListener(Back);  // 1번째 버튼 눌렀을 때 함수호출
    }

    void Back()
    {
        gameManager.GetComponent<GameManager>().RotateController(sliderRotate.GetComponent<Slider>().value);
        Mainmenu.SetActive(true);   // 메인메뉴 활성화
        Optionmenu.SetActive(false);    //옵션메뉴 비활성화
    }
}
