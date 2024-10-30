using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetRackManager : MonoBehaviour
{

    protected Animator animator = null;
    protected AudioSource audioSource = null;
    protected AudioClip clip = null;

    protected string parameter = "CabinetClick";

    private int sheetCount = 0;
    public int SheetCount { get { return sheetCount; } }

    public void Interact()
    {

        animator.SetTrigger(parameter);
        audioSource.PlayOneShot(clip);
        Invoke("AnimationDelay", 1f);

        sheetCount = 1;
    }


    protected void AnimationDelay()
    {
        this.gameObject.SetActive(false);
    }


    public void ResetSheetCount()
    {
        sheetCount = 0;
    }

}
