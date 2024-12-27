using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sink : MonoBehaviour, IInteractable
{
    // 수도꼭지 존재 여부 판별 변수
    private bool isTap = false;
    // 물을 틀기 위해 수도꼭지와 상호작용 헀는지 확인 변수
    private bool isOnTap = false;

    // SinkWater 담을 변수
    SinkWater sinkWater = null;
    // waterAnimator 담을 변수
    Animator waterAnimator = null;

    private void Awake()
    {
        SinkInit();
    }

    // Sink Init 메서드
    private void SinkInit()
    {
        // 컴포넌트들 가져오기
        sinkWater = GetComponentInChildren<SinkWater>();
        waterAnimator = sinkWater.gameObject.GetComponent<Animator>();
        CheckTap();

        // 처음에 물은 없는 상태로 만들기
        sinkWater.gameObject.SetActive(false);
    }

    // 수도꼭지가 있는 지 체크하는 메서드
    private void CheckTap()
    {
        if(SceneManager.GetActiveScene().name != "ClassroomScene") // Sink가 Tap이 있는지 판단하는 로직으로 변경 필요 -> Count + Coroutine으로 변경
        {
            isTap = true;
        }
        else
        {
            isTap = false;
        }    
    }

    public void Interact()
    {
        if (isTap) // 수도꼭지가 세면대에 존재한다면
        {
            // 수도꼭지와 상호작용할 때 마다 물 틀었다 껐다 하기 
            isOnTap = !isOnTap;
            sinkWater.gameObject.SetActive(isOnTap);

            // 만약 물이 틀어진다면
            if (sinkWater.gameObject.activeSelf) 
            { 
                // 애니메이션 재생
                waterAnimator.SetTrigger("IsWater");
            }
        }
        else // 수도꼭지가 없다면
        {

        }
    }
}