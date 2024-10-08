using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftController : MonoBehaviour
{
    public InputActionReference menu; //메뉴 UI 켜는 키
    public InputActionReference collectionOn; //수집품 UI 켜는 키
    public InputActionReference collectionOff; //수집품 UI 끄는 키
    public GameObject UImenu; //메뉴 UI 오브젝트
    public GameObject UIcollection; //수집품 UI 오브젝트

    public GameObject LeftHandRender; //왼쪽 손 랜더러

    private void Start()
    {
        menu.action.performed += MenuOn;
        collectionOn.action.performed += CollectionOn;
        collectionOff.action.performed += CollectionOff;
    }

    void MenuOn(InputAction.CallbackContext context) //메뉴 키 누를 시
    {
         UImenu.SetActive(true);
    }

    void CollectionOn(InputAction.CallbackContext context) //Y키 누를 시
    {
        UIcollection.SetActive(true);
        print("ui킴");
    }
    void CollectionOff(InputAction.CallbackContext context) //X키 누를 시
    {
        UIcollection.SetActive(false);
        print("ui끔");
    }

    public void LeftHandRenderIdle() //기존에 왼손랜더러 켜짐
    {
        LeftHandRender.SetActive(true);
    }

    public void LeftHandRenderGripping() //뭔가를 상호작용시 왼손랜더러 꺼짐
    {
        LeftHandRender.SetActive(false);
    }


}
