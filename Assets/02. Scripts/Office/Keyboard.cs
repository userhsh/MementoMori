using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    private Button[] keyboardButton = new Button[12]; //1~0, DEL, ENTER
    public Button[] KeyboardButton { get { return keyboardButton; } }

    public void KeyboardButtonInit()
    {
        keyboardButton = gameObject.GetComponentsInChildren<Button>();
    }
}