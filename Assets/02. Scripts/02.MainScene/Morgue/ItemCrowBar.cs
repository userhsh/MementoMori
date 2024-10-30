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
        // GameManager 싱글톤 인스턴스 가져오기
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
            print("크로우바 사용");
            strangeTile.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            switchButton.GetComponent<BoxCollider>().enabled = true;

            gameManager.crowbarActive = false; // GameManager의 crowbarActive 상태 업데이트
            gameManager.SaveGameData(transform.position, transform.rotation.eulerAngles); // 데이터 저장
        }
    }
}
