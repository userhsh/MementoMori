using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Groove2 : MonoBehaviour
{
    public GameObject[] Numbers;
    public bool CorrectB = false;
    public GameObject SuccessText;
    public GameObject Password;

    private Vector3 originalParentPosition;
    private Quaternion originalParentRotation;
    private Vector3[] originalLocalChildPositions;
    private Quaternion[] originalLocalChildRotations;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1
        {
            CorrectB = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Numbers[0]) // 1
        {
            print("Á¤´ä");
            CorrectB = false;
        }
    }
}
