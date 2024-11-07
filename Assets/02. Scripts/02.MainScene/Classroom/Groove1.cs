using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Groove1 : MonoBehaviour
{
    public GameObject[] Numbers;
    public bool CorrectA = false;
    public GameObject SuccessText;
    public Groove2 groove2;
    public GameObject Password;
    public bool isFog = false;
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    private Vector3 originalParentPosition;
    private Quaternion originalParentRotation;
    private Vector3[] originalLocalChildPositions;
    private Quaternion[] originalLocalChildRotations;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(Correct());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Numbers[8]) // 9
        {
            CorrectA = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Numbers[8]) // 9
        {
            CorrectA = false;
        }
    }

    private IEnumerator Correct()
    {
        while (Numbers[8].GetComponent<Collider>().enabled == true || Numbers[0].GetComponent<Collider>().enabled == true)
        {
            yield return null;
        }

        audioSource.PlayOneShot(audioClip[2]);
        SuccessText.SetActive(true);
        Password.SetActive(true);
        isFog = true;

        Invoke("CorrectTalkText", 3); //증기가 멈췄다는 대사 3초후 실행
    }

    void CorrectTalkText()
    {
        StartCoroutine(GameObject.Find("PlayerUI").GetComponent<UITalk>().InteractionTalk("증기가 멈춘 것 같다."));
    }
}
