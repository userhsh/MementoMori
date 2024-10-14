using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{

    CanvasGroup gameoverCanvas = null;

    Truck truck = null;

    private void Awake()
    {
        gameoverCanvas = GetComponentInChildren<CanvasGroup>();
        truck = GetComponentInChildren<Truck>();

        gameoverCanvas.alpha = 0f;
        gameoverCanvas.interactable = false;

    }

    private void Update()
    {
        Debug.Log("Truck Destroy Status: " + truck.isTruckDestroy);

        if (truck.isTruckDestroy == true)
        {
            gameoverCanvas.alpha = 1f;
            gameoverCanvas.interactable = true;

            Invoke("BackToStart", 3f);

        }
    }


    private void BackToStart()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("GameStartScene");
        }
    }

}
