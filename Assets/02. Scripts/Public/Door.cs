using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    // 문 잠금 여부 판별 변수
    protected bool isLocked;
    // 문 잠금 여부 프로퍼티
    public bool IsLocked{ get { return isLocked; } set { isLocked = value; } }
    // 불러올 씬 이름 저장할 변수
    protected string moveSceneName = null;
    // 현재 씬 이름 저장할 변수
    protected string currentSceneName = null; 

    // 이동 시 필요한 Scene 이름 저장할 enum 타입 변수
    protected enum SCENENAME
    {
        HallwayScene,    
        MorgueScene,     
        ClassroomScene,  
        OfficeScene,     
        SurgeryScene,    
    }

    // 현재 씬 판단 메서드
    protected void GetCurrentSceneName()
    {
        // 현재 로드된 씬 이름 가져오기
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void Interact()
    {
        if (!isLocked) // 문이 잠겨있지 않다면
        {
            // 문 열기(씬 이동)
            // sceneName으로 씬이동
            SceneManager.LoadScene(moveSceneName);
        }
        else // 문이 잠겼다면
        {
            // 문을 열 수 없음
            print("Door Locked");
        }
    }

    // 문 잠금 해제 메서드
    public void DoorUnlock()
    {
        // 문 잠금을 해제 상태로 바꾸기
        isLocked = false;
    }
}