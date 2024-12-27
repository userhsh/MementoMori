using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class OptionUI : MonoBehaviour
{
    Button button = null;
    public GameObject UIMenu;
    private GameObject Optionmenu;
   private GameObject gameManager;
    private GameObject sliderRotate;

    private void Awake()
    {
        Optionmenu = GameObject.Find("OptionMenu");

        button = GetComponentInChildren<Button>();

        gameManager = GameObject.Find("GameManager");
        sliderRotate = GameObject.Find("Slider Rotate");     
    }

    private void Start()
    {
        button.onClick.AddListener(Back);  // 1��° ��ư ������ �� �Լ�ȣ��
    }

    void Back()
    {
        gameManager.GetComponent<GameManager>().RotateController(sliderRotate.GetComponent<Slider>().value);
        Optionmenu.SetActive(false);    //�ɼǸ޴� ��Ȱ��ȭ
        UIMenu.SetActive(true);   // ���θ޴� Ȱ��ȭ
    }
}
