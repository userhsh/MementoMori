using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TLeftController : XRRayInteractor
{
    public InputActionReference menu; //메뉴 UI 켜는 키
    public InputActionReference collectionOn; //수집품 UI 켜는 키
    public InputActionReference collectionOff; //수집품 UI 끄는 키
    public GameObject UImenu; //메뉴 UI 오브젝트
    public GameObject[] onUIReset;
    public GameObject UIcollection; //수집품 UI 오브젝트

    public GameObject LeftHandRender; //왼쪽 손 랜더러

    public GameObject UIItem;
    public Text UIItemText;

    public GameObject subTitle;
    public Text subTitleText;

    public GameObject UICollectionGet;

    private new void Start()
    {
        menu.action.performed += MenuOn;
        collectionOn.action.performed += CollectionOn;
        collectionOff.action.performed += CollectionOff;
    }

    public void RemoveEvent()
    {
        menu.action.performed -= MenuOn;
        collectionOn.action.performed -= CollectionOn;
        collectionOff.action.performed -= CollectionOff;
    }

    void MenuOn(InputAction.CallbackContext context) //메뉴 키 누를 시
    {
        for (int i = 0; i < onUIReset.Length; i++) // 이전에 켜놨던 UI 초기화 
        {
            onUIReset[i].SetActive(false);
        }

        UImenu?.SetActive(true);
    }

    void CollectionOn(InputAction.CallbackContext context) //Y키 누를 시
    {
        UIcollection?.SetActive(true);
    }
    void CollectionOff(InputAction.CallbackContext context) //X키 누를 시
    {
        UIcollection?.SetActive(false);
    }

    public void LeftHandRenderIdle() //기존에 왼손랜더러 켜짐
    {
        LeftHandRender?.SetActive(true);
    }

    public void LeftHandRenderGripping() //뭔가를 상호작용시 왼손랜더러 꺼짐
    {
        LeftHandRender?.SetActive(false);
    }

    public bool isGrip = true;

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

        isGrip = false;
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
        UIItemText.text = "";
        UIItem.SetActive(false);
        subTitleText.text = "";
        subTitle.SetActive(false);
    }
#pragma warning restore 672
}
