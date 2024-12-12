using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    GameObject pictureDiary = null;
    public GameObject effectFeather;
    private Scalpel scalpel;
    bool isInteractable = false;
    public GameObject devil_doll;
    private Collider collider;

    private void Awake()
    {
        // pictureDiary를 Resources 폴더의 Collection3로 설정
        pictureDiary = Resources.Load("Prefabs/Collection3", typeof(GameObject)) as GameObject;
        scalpel = FindObjectOfType<Scalpel>();
        collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Scalpel")
        {
            isInteractable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Scalpel")
        {
            isInteractable = false;
        }
    }

    public void Interact()
    {
        if (!isInteractable) return;

        // 그림일기 생성
        if (isInteractable)
        {
            scalpel.PlayDollSFX();
            Instantiate(pictureDiary, this.transform.position, this.transform.rotation);
            effectFeather.gameObject.transform.position = this.transform.position;
            effectFeather.SetActive(true);
            Invoke("Effect_Feather_Setactive_false", 5f);
            // 인형 삭제
            devil_doll.SetActive(false);
            collider.enabled = false;
            isInteractable = false;
        }
    }

    void Effect_Feather_Setactive_false()
    {
        effectFeather.SetActive(false);
    }
}