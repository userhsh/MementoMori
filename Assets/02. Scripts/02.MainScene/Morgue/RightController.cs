using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class RightController : XRRayInteractor
{
    public GameObject RightHandRender;
    public GameObject UIItem;
    public Text UIItemText;

    public GameObject subTitle;
    public Text subTitleText;

    public GameObject[] UICollectionGet;

    public void RightHandRenderIdle()
    {
        RightHandRender?.SetActive(true);
    }

    public void RightHandRenderGripping()
    {
        RightHandRender?.SetActive(false);
    }

    public bool isGrip = true; //그립 시 레이방지용 불값

#pragma warning disable 672
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {

        switch (interactable.name)
        {
            case "Collection1":
                UICollectionGet[0].SetActive(true);
                break;
            case "Collection2":
                UICollectionGet[1].SetActive(true);
                break;
            case "Collection3":
                UICollectionGet[2].SetActive(true);
                break;
            case "Collection4":
                UICollectionGet[3].SetActive(true);
                break;
            default:
                break;
        }
        isGrip = false; //그립 시 레이가 상호작용 X
        UIItem.transform.GetChild(1).gameObject.SetActive(false);
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        isGrip = true; //그립 해제 시 레이 상호작용 O
        UIItem.transform.GetChild(1).gameObject.SetActive(false);
    }

    protected override void OnHoverEntered(XRBaseInteractable interactable)
    {
        if (isGrip)
        {
            UIItem.transform.GetChild(1).gameObject.SetActive(true);

            switch (interactable.name)
            {
                case "Doll":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 인형\n...찢을 수 있을 것 같다.";
                    break;
                case "Crowbar":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 크로우바";
                    break;
                case "MorgueKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 시체 안치실 열쇠";
                    break;
                case "DoctorCard":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 의사 카드";
                    break;
                case "CabinetKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 캐비넷 열쇠";
                    break;
                case "Pencil":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 연필";
                    break;
                case "OfficeKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 사무실 열쇠";
                    break;
                case "RemoconPivot":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 리모콘";
                    break;
                case "Flashlight":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 손전등";
                    break;
                case "Paper_None":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 종이";
                    break;
                case "SurgeryKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 수술실 열쇠";
                    break;
                case "Scalpel":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 메스";
                    break;
                case "PillowFabic_Medicine":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 약 묻은 천";
                    break;
                case "Medicine":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    UIItemText.text = "병에 뭐라고 쓰여있다. \n\"묵은 때 제거\"";
                    break;
                case "PillowFabic":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 천";
                    break;
                case "ShutterButton":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 셔터 버튼";
                    break;
                case "Mirror":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    UIItemText.text = "더럽다. 무언가로 닦을 수 있을 것 같다.";
                    break;
                case "BloodCollider":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    UIItemText.text = "무언가 적혔던 흔적이 있다.";
                    break;
                case "StrangeTile":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    UIItemText.text = "수상한 타일이다. \n공구로 떼어낼 수 있을 것 같다.";
                    break;
                case "ButtonHole":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    UIItemText.text = "버튼을 끼울 수 있을 것 같다.";
                    break;
                case "TV":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    UIItemText.text = "리모컨으로 켤 수 있을 것 같다.";
                    break;
                default:
                    break;
            }

            switch (interactable.name)
            {
                case "Collection1":
                    subTitle.SetActive(true);
                    subTitleText.text = "첫번째 수집품";
                    break;
                case "Collection2":
                    subTitle.SetActive(true);
                    subTitleText.text = "두번째 수집품";
                    break;
                case "Collection3":
                    subTitle.SetActive(true);
                    subTitleText.text = "세번째 수집품";
                    break;
                case "Collection4":
                    subTitle.SetActive(true);
                    subTitleText.text = "네번째 수집품";
                    break;
                default:
                    break;
            }

        }


    }

    protected override void OnHoverExited(XRBaseInteractable interactable)
    {
       
        UIItemText.text = "";
        UIItemText.GetComponent<Text>().fontSize = 55;
        UIItem.SetActive(false);
        subTitleText.text = "";
        subTitle.SetActive(false);
    }
#pragma warning restore 672
}
