using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperGET : MonoBehaviour
{
   public TMenuerGetText tmenuerGetText;
    public GameObject truePaper;
    public int pageNumber;
    public GameObject getPaperUI;
    public GameObject menuerEscButton;

    public void GetNumberPaper()
    {
        getPaperUI.SetActive(true);
        menuerEscButton.SetActive(true);

        truePaper.SetActive(false); //�޴��� �� ������ �ر�

        tmenuerGetText.getSetPaperNumber = pageNumber; //������ �ѹ� T�޴���ȹ�� �ؽ�Ʈ �ѹ��� ����
        this.gameObject.SetActive(false);

    }
}
