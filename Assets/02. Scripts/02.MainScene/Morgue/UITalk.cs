using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UITalk : MonoBehaviour
{
    GameObject leftController;
    GameObject rightController;

    public GameObject uiTalk;
    public Text talk;

    string talk1 = "여긴 어디지..?!";
    string talk2 = "아무것도 기억나지 않는다..";

    bool isCoroutine = false;

    private void Awake()
    {
        leftController = GameObject.Find("Left Controller");
        rightController = GameObject.Find("Right Controller");
    }

    private void Start()
    {
        StartCoroutine(StartTalk());
        leftController.SetActive(false);
        rightController.SetActive(false);
        GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0.3f;
    }

    public IEnumerator StartTalk() //시작할 때
    {
        yield return new WaitForSeconds(7f);

        leftController.SetActive(true);
        rightController.SetActive(true);

        leftController.GetComponent<LeftController>().enabled = false;
        rightController.GetComponent<RightController>().enabled = false;
        GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 2f;

        uiTalk.SetActive(true);
        talk.text = "";
        for (int i = 0; i < talk1.Length; i++)
        {
            talk.text += talk1[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);

        talk.text = "";
        for (int i = 0; i < talk2.Length; i++)
        {
            talk.text += talk2[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        uiTalk.SetActive(false);


        leftController.GetComponent<LeftController>().enabled = true;
        rightController.GetComponent<RightController>().enabled = true;

        yield break;
    }

    public IEnumerator InteractionTalk(string _txet)
    {
        if (isCoroutine) yield break;

        isCoroutine = true;
        uiTalk.SetActive(true);

        talk.text = "";
        for (int i = 0; i < _txet.Length; i++)
        {
            talk.text += _txet[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);

        uiTalk.SetActive(false);
        isCoroutine = false;

        yield break;
    }
}
