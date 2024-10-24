using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPaper : MonoBehaviour
{
    public void GetCollection()
    {
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[3] = true;
        this.gameObject.SetActive(false);
    }
}