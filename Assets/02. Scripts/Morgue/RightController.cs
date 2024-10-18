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
        RightHandRender.SetActive(true);
    }

    public void RightHandRenderGripping()
    {
        RightHandRender.SetActive(false);
    }

    public bool isGrip = true; //�׸� �� ���̹����� �Ұ�

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
        isGrip = false; //�׸� �� ���̰� ��ȣ�ۿ� X
        UIItem.transform.GetChild(1).gameObject.SetActive(false);
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        isGrip = true; //�׸� ���� �� ���� ��ȣ�ۿ� O
        UIItem.transform.GetChild(1).gameObject.SetActive(true);
    }

    protected override void OnHoverEntered(XRBaseInteractable interactable)
    {
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
                default:
                    break;
            }

            switch (interactable.name)
            {
                case "Collection1":
                    subTitle.SetActive(true);
                    subTitleText.text = "ù��° ����ǰ";
                    break;
                case "Collection2":
                    subTitle.SetActive(true);
                    subTitleText.text = "�ι�° ����ǰ";
                    break;
                case "Collection3":
                    subTitle.SetActive(true);
                    subTitleText.text = "����° ����ǰ";
                    break;
                case "Collection4":
                    subTitle.SetActive(true);
                    subTitleText.text = "�׹�° ����ǰ";
                    break;
                default:
                    break;
            }

        }


    }

    protected override void OnHoverExited(XRBaseInteractable interactable)
    {
        UIItemText.text = "";
        UIItem.SetActive(false);
        subTitleText.text = "";
        subTitle.SetActive(false);
    }
#pragma warning restore 672
}
