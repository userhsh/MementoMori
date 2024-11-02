using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TLeftController : XRRayInteractor
{
    public InputActionReference menu; //�޴� UI �Ѵ� Ű
    public InputActionReference collectionOn; //����ǰ UI �Ѵ� Ű
    public InputActionReference collectionOff; //����ǰ UI ���� Ű
    public GameObject UImenu; //�޴� UI ������Ʈ
    public GameObject[] onUIReset;
    public GameObject UIcollection; //����ǰ UI ������Ʈ

    public GameObject LeftHandRender; //���� �� ������

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

    void MenuOn(InputAction.CallbackContext context) //�޴� Ű ���� ��
    {
        for (int i = 0; i < onUIReset.Length; i++) // ������ �ѳ��� UI �ʱ�ȭ 
        {
            onUIReset[i].SetActive(false);
        }

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
        UIItemText.text = "";
        UIItem.SetActive(false);
        subTitleText.text = "";
        subTitle.SetActive(false);
    }
#pragma warning restore 672
}
