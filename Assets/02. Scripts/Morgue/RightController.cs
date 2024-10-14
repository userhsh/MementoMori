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

    public void RightHandRenderIdle()
    {
        RightHandRender.SetActive(true);
    }

    public void RightHandRenderGripping()
    {
        RightHandRender.SetActive(false);
    }

    //public void Entering(XRBaseInteractable interactable)
    //{
    //    if (isGrip)
    //    {
    //        switch (interactable.name)
    //        {
    //            case "Doll":
    //                playerUI.SetActive(true);
    //                playerUIText.text = "아이템: 인형";
    //                break;
    //            case "Crowbar":
    //                playerUI.SetActive(true);
    //                playerUIText.text = "아이템: 크로우바";
    //                break;


    //        }
    //    }
    //}

    //public void Exited(XRBaseInteractable interactable)
    //{
    //    playerUIText.text = "";
    //    playerUI.SetActive(false);
    //}

    public bool isGrip = true;
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        isGrip = false;
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        isGrip = true;
    }

    protected override void OnHoverEntered(XRBaseInteractable interactable)
    {

        //if (interactable.transform.childCount != 0)
        //{
        //    interactable?.transform.GetChild(0).gameObject.SetActive(true);
        //    interactable.transform.GetChild(0).GetComponent<TextMesh>().text = "열기";
        //}

        if (isGrip)
        {
            switch (interactable.name)
            {
                case "Doll":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 인형";
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
                case "RemoCon":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 리모콘";
                    break;
                case "Flashlight":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 손전등";
                    break;
                case "Paper_None":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 빈(?)종이";
                    break;  
                case "SurgeryKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 빈(?)종이";
                    break;
                case "Scalpel":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 메스";
                    break; 
                case "PillowFabic_Medicine":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 깨끗한 천";
                    break; 
                case "Medicine":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 약통";
                    break; 
                case "PillowFabic":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 천";
                    break;
            }
        }


    }


    protected override void OnHoverExited(XRBaseInteractable interactable)
    {
        UIItemText.text = "";
        UIItem.SetActive(false);
    }
}
