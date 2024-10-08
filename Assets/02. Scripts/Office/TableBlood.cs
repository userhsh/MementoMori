using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBlood : MonoBehaviour, IInteractable
{
    PaperNone paperNone = null; //획득용 빈종이
    PaperName paperName = null; //이름 적힐 종이
    Pencil pencil = null; 
    SpriteRenderer nameElie = null; //이름

    private void Awake()
    {
        paperName = GetComponentInChildren<PaperName>();
        nameElie = GetComponentInChildren<SpriteRenderer>();
        nameElie.enabled = false; //이름 먼저 가져와서 꺼둔 후에
        paperName.gameObject.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {

        paperNone = other.gameObject.GetComponent<PaperNone>();
        pencil = other.gameObject.GetComponent<Pencil>();

        Interact();

    }

    public void Interact()
    {


        if (paperNone != null)
        {
            Destroy(paperNone.gameObject); //빈 종이 삭제
            paperName.gameObject.SetActive(true); //이름 종이 출현
        }

        if (paperName.enabled == true && pencil != null) //이름 종이 출현 상태에서 연필 대면
        {
            Destroy(pencil.gameObject); //연필 삭제 후
            nameElie.enabled = true; //이름 출현
        }
    }


}
