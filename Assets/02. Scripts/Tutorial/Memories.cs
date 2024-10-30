using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories : MonoBehaviour
{
    public void Collection0Get()
    {
        GameObject.Find("PlayerUI").GetComponent<TUIManager>().collections = true;
        this.gameObject.SetActive(false);
    }
}
