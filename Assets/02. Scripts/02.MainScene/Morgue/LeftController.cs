using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftController : XRRayInteractor
{
    public InputActionReference menu; //메뉴 UI 켜는 키
    public InputActionReference collectionOn; //수집품 UI 켜는 키
    public InputActionReference collectionOff; //수집품 UI 끄는 키
    public GameObject UImenu; //메뉴 UI 오브젝트
    public GameObject UIcollection; //수집품 UI 오브젝트

    public GameObject LeftHandRender; //왼쪽 손 랜더러

    public GameObject UIItem;
    public Text UIItemText;

    public GameObject subTitle;
    public Text subTitleText;

    public GameObject[] UICollectionGet;

    public bool languageEnglish = false;
    public bool languageKorean = false;

    private new void Start()
    {
        //VR기기 버튼에 기능을 펑션하여 추가
        menu.action.performed += MenuOn;
        collectionOn.action.performed += CollectionOn;
        collectionOff.action.performed += CollectionOff;
    }

    public void RemoveEvent()
    {
        //씬 전환 및 로비 이동 시 기능을 해제하여 기능 초기화
        menu.action.performed -= MenuOn;
        collectionOn.action.performed -= CollectionOn;
        collectionOff.action.performed -= CollectionOff;
    }

    void MenuOn(InputAction.CallbackContext context) //메뉴 키 누를 시
    {
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

    //컨트롤러에 interact가 된 아이템을 Hover 시
    protected override void OnHoverEntered(XRBaseInteractable interactable)
    {
        if (isGrip) //레이가 상호작용 가능한 상태라면
        {
            //UIItem의 자식인 텍스트 박스을 활성화
            UIItem.transform.GetChild(1).gameObject.SetActive(true);
        
            switch (interactable.name) //오브젝트 이름과 비교
            {
                case "Doll": //인형
                    UIItem.SetActive(true);
                    if (languageEnglish) //영어설정 시
                    {   //UI텍스트 상자에 아이템: 이름, 설명 표시
                        UIItemText.text = "Item: Doll\n...can rip this off";
                    }
                    else if (languageKorean) //한국어 설정 시
                    {
                        UIItemText.text = "아이템: 인형\n...찢을 수 있을 것 같다.";
                    }
                    break;
                case "Crowbar": //크로우바
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Crowbar";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 크로우바";
                    }
                    break;
                case "MorgueKey": //안치실 열쇠
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Morgue Key";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 시체 안치실 열쇠";
                    }

                    break;
                case "DoctorCard":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: ID Card";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: ID 카드";
                    }

                    break;
                case "CabinetKey":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Cabinet Key";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 캐비넷 열쇠";
                    }

                    break;
                case "Pencil":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Pencil";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 연필";
                    }

                    break;
                case "OfficeKey":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Office Key";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 사무실 열쇠";
                    }

                    break;
                case "RemoconPivot":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Remocon";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 리모콘";
                    }

                    break;
                case "Flashlight":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Flashlight";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 손전등";
                    }

                    break;
                case "Paper_None":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Paper_None";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 종이";
                    }

                    break;
                case "SurgeryKey":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Surgery Key";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 수술실 열쇠";
                    }

                    break;
                case "Scalpel":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Scalpel";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 메스";
                    }

                    break;
                case "PillowFabic_Medicine":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Medicated cloth";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 약 묻은 천";
                    }

                    break;
                case "Medicine":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    if (languageEnglish)
                    {
                        UIItemText.text = "It says something on the bottle. \n\"Remove dirt\"";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "병에 뭐라고 쓰여있다. \n\"묵은 때 제거\"";
                    }

                    break;
                case "PillowFabic":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Cloth";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 천";
                    }

                    break;
                case "ShutterButton":
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Shutter button";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "아이템: 셔터 버튼";
                    }

                    break;
                case "Mirror":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    if (languageEnglish)
                    {
                        UIItemText.text = "It's dirty. I think I can wipe it with something.";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "더럽다. 무언가로 닦을 수 있을 것 같다.";
                    }

                    break;
                case "BloodCollider":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    if (languageEnglish)
                    {
                        UIItemText.text = "There are traces of something written on it.";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "무언가 적혔던 흔적이 있다.";
                    }

                    break;
                case "StrangeTile":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    if (languageEnglish)
                    {
                        UIItemText.text = "It's a suspicious tile. \nI think it can be removed with a \"tool\".";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "수상한 타일이다. \n공구로 떼어낼 수 있을 것 같다.";
                    }

                    break;
                case "ButtonHole":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    if (languageEnglish)
                    {
                        UIItemText.text = "Can attach a button.";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "버튼을 끼울 수 있을 것 같다.";
                    }

                    break;
                case "TV":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    UIItemText.GetComponent<Text>().fontSize = 45;
                    if (languageEnglish)
                    {
                        UIItemText.text = "Can turn it on with a remocon.";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "리모컨으로 켤 수 있을 것 같다.";
                    }

                    break;
                case "Ramen":
                    UIItem.SetActive(true);
                    UIItem.transform.GetChild(1).gameObject.SetActive(false);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Ramen. \nJust one bite..?";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "라면이다. \n한입만...?";
                    }

                    break;
                default:
                    break;
            }

            switch (interactable.name)
            {
                case "Collection1":
                    subTitle.SetActive(true);
                    if (languageEnglish)
                    {
                        subTitleText.text = "First Collection";
                    }
                    else if (languageKorean)
                    {
                        subTitleText.text = "첫번째 수집품";
                    }

                    break;
                case "Collection2":
                    subTitle.SetActive(true);
                    if (languageEnglish)
                    {
                        subTitleText.text = "Second Collection";
                    }
                    else if (languageKorean)
                    {
                        subTitleText.text = "두번째 수집품";
                    }

                    break;
                case "Collection3":
                    subTitle.SetActive(true);
                    if (languageEnglish)
                    {
                        subTitleText.text = "Third Collection";
                    }
                    else if (languageKorean)
                    {
                        subTitleText.text = "세번째 수집품";
                    }

                    break;
                case "Collection4":
                    subTitle.SetActive(true);
                    if (languageEnglish)
                    {
                        subTitleText.text = "Fourth Collection";
                    }
                    else if (languageKorean)
                    {
                        subTitleText.text = "네번째 수집품";
                    }

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
