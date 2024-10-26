using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtDiary : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.name = "Collection3";
    }
    public void Collection3Get()
    {
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[2] = true;
        this.gameObject.SetActive(false);
    }

}
