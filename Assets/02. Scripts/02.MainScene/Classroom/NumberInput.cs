using UnityEngine;
using TMPro;

public class NumberInput : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI displayText1;  // ù ��° ���� �ؽ�Ʈ
    [SerializeField]
    private TextMeshProUGUI displayText2;  // �� ��° ���� �ؽ�Ʈ
    [SerializeField]
    private GameObject successText; // ���� �ؽ�Ʈ
    [SerializeField]
    private GameObject passwordObject;     // Password ������Ʈ (��Ȱ��ȭ/Ȱ��ȭ�� ������Ʈ)

    private int firstInputNumber = 0;     // ù ��° �Է� ����
    private int secondInputNumber = 0;    // �� ��° �Է� ����

    private int firstNumber = 1;          // ���� ù ��° ����
    private int secondNumber = 1;         // ���� �� ��° ����

    private bool isCorrect = false;
    public bool IsCorrect { get { return isCorrect; } }

    private void Start()
    {
        // Password ������Ʈ ��Ȱ��ȭ
        if (passwordObject != null)
        {
            passwordObject.SetActive(false);
            successText.SetActive(false);
        }
    }

    // ù ��° ���� ���� ��ư�� ������ ȣ��Ǵ� �Լ�
    public void IncreaseFirstNumber()
    {
        firstInputNumber = (firstInputNumber + 1) % 10;  // ���� 0~9 ��ȯ
        displayText1.text = firstInputNumber.ToString(); // ù ��° ���� ������Ʈ
    }

    // �� ��° ���� ���� ��ư�� ������ ȣ��Ǵ� �Լ�
    public void IncreaseSecondNumber()
    {
        secondInputNumber = (secondInputNumber + 1) % 10;  // ���� 0~9 ��ȯ
        displayText2.text = secondInputNumber.ToString();  // �� ��° ���� ������Ʈ
    }

    // ���� Ȯ�� ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void SubmitNumbers()
    {
        if (firstInputNumber == firstNumber && secondInputNumber == secondNumber)
        {
            CorrectAnswerAction();  // ������ �� ������ �Լ�
        }
    }

    // ������ ������ �� ������ �Լ�
    private void CorrectAnswerAction()
    {
        if (passwordObject != null)
        {
            // Password ������Ʈ Ȱ��ȭ
            passwordObject.SetActive(true);
            successText.SetActive(true);
            isCorrect = true;
        }
        else
        {
            Debug.LogError("Password ������Ʈ�� �������� �ʾҽ��ϴ�.");
        }
    }
}