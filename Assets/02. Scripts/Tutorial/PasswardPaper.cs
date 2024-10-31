using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswardPaper : MonoBehaviour
{
    Animator animator;
    public GameObject passwardPaperUI;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
    }
    public void PaperClick()
    {
        this.animator.SetBool("Click", true);
        passwardPaperUI.SetActive(true);
    }

}
