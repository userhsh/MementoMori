using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswardPaper : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip ClickSound;
    Animator animator;
    public GameObject passwardPaperUI;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ClickSound = Resources.Load<AudioClip>("TutorialSFX/ClickSound/ClickSound");
    }

    public void PaperClick()
    {
        this.animator.SetBool("Click", true);
        passwardPaperUI.SetActive(true);
        audioSource.PlayOneShot(ClickSound);
    }

}
