using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private GameManager gameManager; // GameManager 변수 선언

    //메뉴창에 있는 기능
    public GameObject UIMenu;
    public GameObject OptionMenu;
    public GameObject optionButton;
    public GameObject exitButton;

    //수집품에 있는 기능
    public bool[] collections = new bool[4];
    public GameObject[] collectionButtonLocks;
    public GameObject[] collectionButtons;
    public GameObject collectionLockImg;
    public GameObject[] collectionImgs;

    public LeftController leftController;

    private bool isAllCollection = false;
    public bool IsAllCollection { get { return isAllCollection; } }

    int collectionCount = 0;

    private void Awake()
    {
        for (int i = 0; i < collections.Length; i++)
        {
            collections[i] = false;
        }
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.Log("GameManager not found in the scene!");
        }
    }

    private void Update()
    {
        // 수집품 획득 시 수집품UI의 버튼 해금
        for (int i = 0; i < collections.Length; i++)
        {
            if (collections[i] == true)
            {
                collectionButtonLocks[i].gameObject.SetActive(false);
                collectionButtons[i].gameObject.SetActive(true);
            }
        }

        CheckCollection();
    }

    public void ReturnButton() //돌아가기 버튼 누를 시 메뉴 닫음
    {
        UIMenu.SetActive(false);
    }
    public void OptionButton()
    {
        UIMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }
    public void ExitButton()
    {
        leftController.RemoveEvent();

        if (gameManager != null)
        {
            // Exit 버튼을 클릭했을 때 수행할 작업
            PlayerController playerController = FindObjectOfType<PlayerController>(); // 현재 씬에서 플레이어 객체를 찾음
            if (playerController != null)
            {
                // 플레이어의 위치와 회전값을 저장
                Vector3 playerPosition = playerController.transform.position; // 플레이어 위치
                Vector3 playerRotation = playerController.transform.rotation.eulerAngles; // 플레이어 회전값

                gameManager.SaveGameData(playerPosition, playerRotation); // 플레이어 위치와 회전값 저장
            }
            else
            {
                Debug.Log("PlayerController not found in ExitButton!");
            }
        }
        else
        {
            Debug.Log("GameManager is null in ExitButton!");
        }

        SceneManager.LoadScene("GameStartScene"); // 첫 번째 씬으로 전환
    }

    public void CollectionOpen(int _collectionNumber)
    {
        for (int i = 0; i < collectionImgs.Length; i++)
        {
            collectionImgs[i].gameObject.SetActive(false);
        }
        if (_collectionNumber >= 0 && _collectionNumber < collectionImgs.Length)
        {
            collectionLockImg.gameObject.SetActive(false);
            collectionImgs[_collectionNumber].gameObject.SetActive(true);
        }
    }


    private void CheckCollection()
    {
        collectionCount = 0;

        for (int i = 0; i < collections.Length; i++)
        {
            if (collections[i])
            {
                collectionCount++;
            }
        }

        if (collectionCount >= 4)
        {
            isAllCollection = true;
        }
    }


}
