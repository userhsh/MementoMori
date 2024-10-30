using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SheetRack : MonoBehaviour
{
    Transform[] originSheetTrans = null; //���� ��ġ��

    GameObject[] sheetRackObjects = null; //������Ʈ ��Ƽ�� Ȯ�ο�

    SheetRackCase[] sheetRackCases = null; //������Ʈ ȣ��

    int totalSheetCount = -1;

    bool isClear = false;

    private void Awake()
    {
        sheetRackCases = GetComponentsInChildren<SheetRackCase>();


        originSheetTrans = new Transform[sheetRackCases.Length];
        sheetRackObjects = new GameObject[sheetRackCases.Length];

        for (int i = 0; i < sheetRackCases.Length; i++)
        {
            originSheetTrans[i] = sheetRackCases[i].transform;
            sheetRackObjects[i] = sheetRackCases[i].gameObject;
        }

    }

    private void Start()
    {
        StartCoroutine(CheckCount());
    }

    private void ResetCaseActive()
    {

        for (int i = 0; i < sheetRackObjects.Length; i++)
        {
            if (!sheetRackObjects[i].gameObject.activeInHierarchy)
            {
                sheetRackObjects[i].gameObject.SetActive(true);
            }
        }

    }


    private IEnumerator CheckCount()
    {
        while (!isClear)
        {
            foreach (var sheet in sheetRackCases)
            {
                totalSheetCount += sheet.SheetCount;
                sheet.ResetSheetCount();

                if (totalSheetCount > 2)
                {
                    totalSheetCount = 0;
                    sheet.ResetSheetCount();
                    ResetCaseActive();
                }
            }

            // Ư�� ������ �� isClear == false �� �ٲ� > ����^^

            yield return null;
        }
    }
}