using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    TVPW tvPW = null; //TV�� ������� ���� ��й�ȣ �̹���(�ڽ� ������Ʈ)
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
            // tvPW ���������� ���� ���������� ��
            tvPW.gameObject.SetActive(!tvPW.gameObject.activeSelf);
            audioSource.PlayOneShot(TVSFX);
        }
        else
        {
            Debug.Log("�ٸ� ���� ����غ���.");
        }
    }
}
