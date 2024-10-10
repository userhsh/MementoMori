using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour, IInteractable
{
    public Fabric fabric;

    private void Awake()
    {
        fabric.gameObject.SetActive(false);
    }

    public void Interact()
    {
        // 玫 积己
        fabric.gameObject.SetActive(true);
        // 海俺 力芭
        Destroy(gameObject);
    }
}