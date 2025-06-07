using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftController : XRRayInteractor
{
    public InputActionReference menu; //�޴� UI �Ѵ� Ű
    public InputActionReference collectionOn; //����ǰ UI �Ѵ� Ű
    public InputActionReference collectionOff; //����ǰ UI ���� Ű
    public GameObject UImenu; //�޴� UI ������Ʈ
    public GameObject UIcollection; //����ǰ UI ������Ʈ

    public GameObject LeftHandRender; //���� �� ������

    public GameObject UIItem;
    public Text UIItemText;

    public GameObject subTitle;
    public Text subTitleText;

    public GameObject[] UICollectionGet;

    public bool languageEnglish = false;
    public bool languageKorean = false;

    private new void Start()
    {
        //VR��� ��ư�� ����� ����Ͽ� �߰�
        menu.action.performed += MenuOn;
        collectionOn.action.performed += CollectionOn;
        collectionOff.action.performed += CollectionOff;
    }

    public void RemoveEvent()
    {
        //�� ��ȯ �� �κ� �̵� �� ����� �����Ͽ� ��� �ʱ�ȭ
        menu.action.performed -= MenuOn;
        collectionOn.action.performed -= CollectionOn;
        collectionOff.action.performed -= CollectionOff;
    }

    void MenuOn(InputAction.CallbackContext context) //�޴� Ű ���� ��
    {
        UImenu?.SetActive(true);
    }

    void CollectionOn(InputAction.CallbackContext context) //YŰ ���� ��
    {
        UIcollection?.SetActive(true);
    }
    void CollectionOff(InputAction.CallbackContext context) //XŰ ���� ��
    {
        UIcollection?.SetActive(false);
    }

    public void LeftHandRenderIdle() //������ �޼շ����� ����
    {
        LeftHandRender?.SetActive(true);
    }

    public void LeftHandRenderGripping() //������ ��ȣ�ۿ�� �޼շ����� ����
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
        isGrip = false; //�׸� �� ���̰� ��ȣ�ۿ� X
        UIItem.transform.GetChild(1).gameObject.SetActive(false);
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        isGrip = true; //�׸� ���� �� ���� ��ȣ�ۿ� O
        UIItem.transform.GetChild(1).gameObject.SetActive(false);
    }

    //��Ʈ�ѷ��� interact�� �� �������� Hover ��
    protected override void OnHoverEntered(XRBaseInteractable interactable)
    {
        if (isGrip) //���̰� ��ȣ�ۿ� ������ ���¶��
        {
            //UIItem�� �ڽ��� �ؽ�Ʈ �ڽ��� Ȱ��ȭ
            UIItem.transform.GetChild(1).gameObject.SetActive(true);
        
            switch (interactable.name) //������Ʈ �̸��� ��
            {
                case "Doll": //����
                    UIItem.SetActive(true);
                    if (languageEnglish) //����� ��
                    {   //UI�ؽ�Ʈ ���ڿ� ������: �̸�, ���� ǥ��
                        UIItemText.text = "Item: Doll\n...can rip this off";
                    }
                    else if (languageKorean) //�ѱ��� ���� ��
                    {
                        UIItemText.text = "������: ����\n...���� �� ���� �� ����.";
                    }
                    break;
                case "Crowbar": //ũ�ο��
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Crowbar";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "������: ũ�ο��";
                    }
                    break;
                case "MorgueKey": //��ġ�� ����
                    UIItem.SetActive(true);
                    if (languageEnglish)
                    {
                        UIItemText.text = "Item: Morgue Key";
                    }
                    else if (languageKorean)
                    {
                        UIItemText.text = "������: ��ü ��ġ�� ����";
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
                        UIItemText.text = "������: ID ī��";
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
                        UIItemText.text = "������: ĳ��� ����";
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
                        UIItemText.text = "������: ����";
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
                        UIItemText.text = "������: �繫�� ����";
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
                        UIItemText.text = "������: ������";
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
                        UIItemText.text = "������: ������";
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
                        UIItemText.text = "������: ����";
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
                        UIItemText.text = "������: ������ ����";
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
                        UIItemText.text = "������: �޽�";
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
                        UIItemText.text = "������: �� ���� õ";
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
                        UIItemText.text = "���� ����� �����ִ�. \n\"���� �� ����\"";
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
                        UIItemText.text = "������: õ";
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
                        UIItemText.text = "������: ���� ��ư";
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
                        UIItemText.text = "������. ���𰡷� ���� �� ���� �� ����.";
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
                        UIItemText.text = "���� ������ ������ �ִ�.";
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
                        UIItemText.text = "������ Ÿ���̴�. \n������ ��� �� ���� �� ����.";
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
                        UIItemText.text = "��ư�� ���� �� ���� �� ����.";
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
                        UIItemText.text = "���������� �� �� ���� �� ����.";
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
                        UIItemText.text = "����̴�. \n���Ը�...?";
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
                        subTitleText.text = "ù��° ����ǰ";
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
                        subTitleText.text = "�ι�° ����ǰ";
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
                        subTitleText.text = "����° ����ǰ";
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
                        subTitleText.text = "�׹�° ����ǰ";
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
