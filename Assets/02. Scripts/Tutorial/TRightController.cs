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

    public bool isGrip = true; //그립 시 레이방지용 불값

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
        isGrip = false; //그립 시 레이가 상호작용 X
        UIItem.transform.GetChild(1).gameObject.SetActive(false);
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        isGrip = true; //그립 해제 시 레이 상호작용 O
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
                    UIItemText.text = "아이템: 경찰 보안카드";
                    break;
                case "Ammo":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 탄약";
                    break; 
                case "Gun":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 권총";
                    break;
                case "GunAmmo":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 장전 된 권총";
                    break;   
                case "PoilceKey":
                    UIItem.SetActive(true);
                    UIItemText.text = "아이템: 문 열쇠";
                    break;
                default:
                    break;
            }

            switch (interactable.name)
            {
                case "Collection0":
                    subTitle.SetActive(true);
                    subTitleText.text = "수집품";
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
