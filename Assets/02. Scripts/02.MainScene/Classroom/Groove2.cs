using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


public class Groove2 : MonoBehaviour
{
    public GameObject[] Numbers;
    public bool CorrectB = false;
    public GameObject SuccessText;
    public GameObject Password;
    public bool IsWrong = false;

    private Vector3 originalParentPosition;
    private Quaternion originalParentRotation;
    private Vector3[] originalLocalChildPositions;
    private Quaternion[] originalLocalChildRotations;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1
        {
            CorrectB = true;
        }
        else
        {
            if (!other.CompareTag("SpotLight"))
            {
                IsWrong = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1
        {
            CorrectB = false;
        }
        else
        {
            if (!other.CompareTag("SpotLight"))
            {
                IsWrong = false;
            }
        }
    }
}
