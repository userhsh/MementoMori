using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLogoEvent : MonoBehaviour
{
    TLeftController TleftController;
    MainmenuButtons mainmenuButtons;
    public MainmenuButtons MainmenuButtons;

    private void Awake()
    {
        mainmenuButtons = GetComponent<MainmenuButtons>();
    }
    public void Warp() //�ӽ������� Ŭ������� �̵�, ��Ʈ�ѷ� ǥ��X
    {
        GameObject.Find("Player").transform.position = new Vector3(0, -1.5f, 0);
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
    }

    public void NextScene()
    {
        TleftController.RemoveEvent(); //��� ����
        GameManager.Instance.isTutorial = false;

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // �� ���� ���� �޼ҵ� ȣ��
            mainmenuButtons.continueButton.interactable = true; // �� ������ ����Ǿ����Ƿ� �̾��ϱ� ��ư Ȱ��ȭ
        }
        else
        {
            Debug.LogError("GameManager�� ã�� �� �����ϴ�!"); // GameManager�� ���� ��� ���� �α� ���
        }
    }
}
