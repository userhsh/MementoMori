using UnityEngine;
using TMPro;

public class NumberInput : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI displayText1;  // 첫 번째 숫자 텍스트
    [SerializeField]
    private TextMeshProUGUI displayText2;  // 두 번째 숫자 텍스트
    [SerializeField]
    private GameObject successText; // 정답 텍스트
    [SerializeField]
    private GameObject passwordObject;     // Password 오브젝트 (비활성화/활성화할 오브젝트)

    private int firstInputNumber = 0;     // 첫 번째 입력 숫자
    private int secondInputNumber = 0;    // 두 번째 입력 숫자

    private int firstNumber = 1;          // 정답 첫 번째 숫자
    private int secondNumber = 1;         // 정답 두 번째 숫자

    private void Start()
    {
        // Password 오브젝트 비활성화
        if (passwordObject != null)
        {
            passwordObject.SetActive(false);
            successText.SetActive(false);
        }
    }

    // 첫 번째 숫자 증가 버튼을 누르면 호출되는 함수
    public void IncreaseFirstNumber()
    {
        firstInputNumber = (firstInputNumber + 1) % 10;  // 숫자 0~9 순환
        displayText1.text = firstInputNumber.ToString(); // 첫 번째 숫자 업데이트
    }

    // 두 번째 숫자 증가 버튼을 누르면 호출되는 함수
    public void IncreaseSecondNumber()
    {
        secondInputNumber = (secondInputNumber + 1) % 10;  // 숫자 0~9 순환
        displayText2.text = secondInputNumber.ToString();  // 두 번째 숫자 업데이트
    }

    // 정답 확인 버튼을 눌렀을 때 호출되는 함수
    public void SubmitNumbers()
    {
        if (firstInputNumber == firstNumber && secondInputNumber == secondNumber)
        {
            Debug.Log("정답입니다!");
            CorrectAnswerAction();  // 정답일 때 실행할 함수
        }
        else
        {
            Debug.Log("틀린 답입니다. 다시 시도하세요.");
        }
    }

    // 정답을 맞췄을 때 실행할 함수
    private void CorrectAnswerAction()
    {
        Debug.Log("정답을 맞췄습니다! Password 오브젝트를 활성화합니다.");

        if (passwordObject != null)
        {
            // Password 오브젝트 활성화
            passwordObject.SetActive(true);
            successText.SetActive(true);
        }
        else
        {
            Debug.LogError("Password 오브젝트가 설정되지 않았습니다.");
        }
    }
}