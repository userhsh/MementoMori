using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemCrowBar : MonoBehaviour
{
    public bool use = false;

    public GameObject strangeTile;
    public GameObject switchButton;

    private GameManager gameManager;

    private void Start()
    {
        // GameManager �̱��� �ν��Ͻ� ��������
        gameManager = GameManager.GetInstance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "StrangeTile")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "StrangeTile")
        {
            use = false;
        }
    }

    public void Use()
    {
        if (use == true)
        {
            print("ũ�ο�� ���");
            strangeTile.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            switchButton.GetComponent<BoxCollider>().enabled = true;

            gameManager.crowbarActive = false; // GameManager�� crowbarActive ���� ������Ʈ
            gameManager.SaveGameData(transform.position, transform.rotation.eulerAngles); // ������ ����
        }
    }
}
