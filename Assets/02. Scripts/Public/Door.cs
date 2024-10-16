using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    // �� ��� ���� �Ǻ� ����
    protected bool isLocked;
    // �� ��� ���� ������Ƽ
    public bool IsLocked { get { return isLocked; } set { isLocked = value; } }
    // �ҷ��� �� �̸� ������ ����
    protected string moveSceneName = null;
    // ���� �� �̸� ������ ����
    protected string currentSceneName = null;

    protected Vector3 startPos;

    // �̵� �� �ʿ��� Scene �̸� ������ enum Ÿ�� ����
    protected enum SCENENAME
    {
        HallwayScene,    
        MorgueScene,     
        ClassroomScene,  
        OfficeScene,     
        SurgeryScene,    
    }

    // ���� �� �Ǵ� �޼���
    protected void GetCurrentSceneName()
    {
        // ���� �ε�� �� �̸� ��������
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void Interact()
    {
        if (!isLocked) // ���� ������� �ʴٸ�
        {
            // �� ����(�� �̵�)
            // sceneName���� ���̵�
            SceneManager.LoadScene(moveSceneName);
        }
        else // ���� ���ٸ�
        {
            // ���� �� �� ����
            print("Door Locked");
        }
    }

    // �� ��� ���� �޼���
    public void DoorUnlock()
    {
        // �� ����� ���� ���·� �ٲٱ�
        isLocked = false;
    }
}