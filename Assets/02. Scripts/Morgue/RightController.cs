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
    //                playerUIText.text = "������: ����";
    //                break;
    //            case "Crowbar":
    //                playerUI.SetActive(true);
    //                playerUIText.text = "������: ũ�ο��";
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
        //    interactable.transform.GetChild(0).GetComponent<TextMesh>().text = "����";
        //}

        if (isGrip)
        {
            switch (interactable.name)
            {
                case "Doll":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ����";
                    break;
                case "Crowbar":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ũ�ο��";
                    break;
                case "MorgueKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ��ü ��ġ�� ����";
                    break;
                case "DoctorCard":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: �ǻ� ī��";
                    break;
                case "CabinetKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ĳ��� ����";
                    break;
                case "Pencil":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ����";
                    break;
                case "OfficeKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: �繫�� ����";
                    break;
                case "RemoCon":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ������";
                    break;
                case "Flashlight":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ������";
                    break;
                case "Paper_None":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ��(?)����";
                    break;  
                case "SurgeryKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ��(?)����";
                    break;
                case "Scalpel":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: �޽�";
                    break; 
                case "PillowFabic_Medicine":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ������ õ";
                    break; 
                case "Medicine":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ����";
                    break; 
                case "PillowFabic":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: õ";
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
