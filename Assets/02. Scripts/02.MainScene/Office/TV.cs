using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    TVPW tvPW = null; //TV에 띄워지는 현관 비밀번호 이미지(자식 오브젝트)
    private AudioSource audioSource;
    private AudioClip TVSFX;

    private void Awake()
    {
        tvPW = GetComponentInChildren<TVPW>();
        tvPW.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        TVSFX = Resources.Load<AudioClip>("OfficeSFX/TVSFX");
    }

    public void Interact()
    {
        if (tvPW != null)
        {
            // tvPW 켜져있으면 끄고 꺼져있으면 켬
            tvPW.gameObject.SetActive(!tvPW.gameObject.activeSelf);
            audioSource.clip = TVSFX;
            audioSource.Play();
        }
        else
        {
        
        }
    }
}
