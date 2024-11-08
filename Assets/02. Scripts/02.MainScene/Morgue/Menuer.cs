using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuer : MonoBehaviour
{
    public GameObject menu;

    public void MenuerClose()
    {
        menu.SetActive(false);
    }
}
