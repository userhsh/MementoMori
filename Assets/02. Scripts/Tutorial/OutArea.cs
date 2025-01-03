using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.XR.Interaction.Toolkit;

public class OutArea : MonoBehaviour
{
    public bool condition1 = false;
    public bool condition2 = false;
    public bool notAmmo = false;
    public bool nextfullcheck = false;
    public TUITalk tUITalk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GunAmmo")
        {
            condition1 = true;
        }
        if (other.gameObject.name == "Body")
        {
            condition2 = true;
        }
        if (other.gameObject.name == "Gun")
        {
            notAmmo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GunAmmo")
        {
            condition1 = false;
        }
        if (other.gameObject.name == "Body")
        {
            condition2 = false;
        }
        if (other.gameObject.name == "Gun")
        {
            notAmmo = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (condition1 == true && condition2 == true)
        {
            condition1 = false;
            condition2 = false;
            notAmmo = false;
            nextfullcheck = true;
            GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerFootsteps>().enabled = false;
            GameObject.Find("Player").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("GunAmmo").GetComponent<Gun>().dontText = true;
            GameObject.Find("OutArea").GetComponent<Transform>().localScale = new Vector3(6, 1.259817f, 6); //에어리어 공간 크게하여 재진입 방지
            tUITalk.StopAllCoroutines();
            tUITalk.UITalk.SetActive(false);
            StartCoroutine(tUITalk.OutAreaTalk());
        }
        else if (condition2 == true && notAmmo == true) //총알이 없다면
        {
            if (nextfullcheck == false)
            {
                condition1 = false;
                condition2 = false;
                notAmmo = false;
                StartCoroutine(tUITalk.NotAmmoOutAreaTalk());
            }

        }
        else if (condition2 == true) //그냥 나가면
        {
            if (nextfullcheck == false)
            {
                condition1 = false;
                condition2 = false;
                notAmmo = false;
                StartCoroutine(tUITalk.NotOutAreaTalk());
            }

        }


    }

}
