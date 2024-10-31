using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TRightController : XRRayInteractor
{
    public GameObject RightHandRender;
    public GameObject UIItem;
    public Text UIItemText;

    public GameObject subTitle;
    public Text subTitleText;

    public GameObject UICollectionGet;

    public void RightHandRenderIdle()
    {
        RightHandRender?.SetActive(true);
    }

    public void RightHandRenderGripping()
    {
        RightHandRender?.SetActive(false);
    }

    public bool isGrip = true; //�׸� �� ���̹����� �Ұ�

#pragma warning disable 672
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {

        switch (interactable.name)
        {
            case "Collection0":
                UICollectionGet.SetActive(true);
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
                case "PoliceCard":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ���� ����ī��";
                    break;
                case "Ammo":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ź��";
                    break; 
                case "Gun":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ����";
                    break;
                case "GunAmmo":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: ���� �� ����";
                    break;   
                case "PoilceKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "������: �� ����";
                    break;
                default:
                    break;
            }

            switch (interactable.name)
            {
                case "Collection0":
                    subTitle.SetActive(true);
                    subTitleText.text = "����ǰ";
                    break;
                default:
                    break;
            }

        }


    }

    protected override void OnHoverExited(XRBaseInteractable interactable)
    {
        UIItem.transform.GetChild(1).gameObject.SetActive(true);
        UIItemText.text = "";
        UIItem.SetActive(false);
        subTitleText.text = "";
        subTitle.SetActive(false);
    }
#pragma warning restore 672
}
