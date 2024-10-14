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


    private void Start()
    {
        menu.action.performed += MenuOn;
        collectionOn.action.performed += CollectionOn;
        collectionOff.action.performed += CollectionOff;
    }

    void MenuOn(InputAction.CallbackContext context) //�޴� Ű ���� ��
    {
         UImenu.SetActive(true);
    }

    void CollectionOn(InputAction.CallbackContext context) //YŰ ���� ��
    {
        UIcollection.SetActive(true);
        print("uiŴ");
    }
    void CollectionOff(InputAction.CallbackContext context) //XŰ ���� ��
    {
        UIcollection.SetActive(false);
        print("ui��");
    }

    public void LeftHandRenderIdle() //������ �޼շ����� ����
    {
        LeftHandRender.SetActive(true);
    }

    public void LeftHandRenderGripping() //������ ��ȣ�ۿ�� �޼շ����� ����
    {
        LeftHandRender.SetActive(false);
    }

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
