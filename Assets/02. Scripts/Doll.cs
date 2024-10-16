using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    GameObject pictureDiary = null;

    bool isInteractable = false;

    private void Awake()
    {
        // pictureDiary를 Resources 폴더의 Collection3로 설정
        pictureDiary = Resources.Load("Prefabs/Collection3", typeof(GameObject)) as GameObject;
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
        Instantiate(pictureDiary, this.transform.position, this.transform.rotation);
        // 인형 삭제
        Destroy(this.gameObject);
    }
}