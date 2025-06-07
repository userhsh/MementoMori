using NavKeypad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainDoorLocker : MonoBehaviour
{
    public Keypad surgeryKeypad = null;
    public UIManager uiManager = null;

    public LeftController leftController;

    bool isGameclear = false;

    private void Update()
    {
        GameClear();
    }

    private void GameClear()
    {
        if (surgeryKeypad.AccessWasGranted)
        {
            isGameclear = true;
        }

        ChangeEndingScene();
    }

    private void ChangeEndingScene()
    {
        if (!isGameclear) return;

        leftController.RemoveEvent();

        if (uiManager.IsAllCollection)
        {
            SceneManager.LoadScene("TrueEndingScene");
        }
        else
        {
            SceneManager.LoadScene("NomalEndingScene");
        }
    }
}