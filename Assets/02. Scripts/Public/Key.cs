using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour, IUseable
{
    // 존재하는 문들을 담을 변수 선언
    protected MorgueDoor morgueDoor = null;
    protected ClassroomDoor classroomDoor = null;
    protected OfficeDoor officeDoor = null;
    protected SurgeryDoor surgeryDoor = null;

    // KEY 상태를 판단할 enum 변수 선언 
    protected enum KEY
    {
        MorgueKey,
        ClassroomKey,
        OfficeKey,
        SurgeryKey,
    }
    // 현재 key 상태를 저장할 변수 선언
    protected KEY currentKey = 0;

    // 아이템 획득 메서드
    public void GetItem(Transform _pos)
    {
        transform.SetParent(_pos);
        transform.position = _pos.position;
    }

    // 아이템 사용 메서드
    // _collider를 인자로 받아서 사용
    public void Use(Collider _collider)
    {
        DoorUnLockFromKey(_collider);
    }

    // 문 잠금 해제 메서드
    private void DoorUnLockFromKey(Collider _collider) // 인자로 _collider를 받음
    {
        // currentKey의 상태에 따라 switch문 실행
        switch (currentKey)
        {
            // MorgueKey일 때
            case KEY.MorgueKey:
                morgueDoor = _collider.gameObject.GetComponent<MorgueDoor>();
                morgueDoor?.DoorUnlock();
                break;
            // ClassroomKey일 때
            case KEY.ClassroomKey:
                classroomDoor = _collider.gameObject.GetComponent<ClassroomDoor>();
                classroomDoor?.DoorUnlock();
                break;
            // OfficeKey일 때
            case KEY.OfficeKey:
                officeDoor = _collider.gameObject.GetComponent<OfficeDoor>();
                officeDoor?.DoorUnlock();
                break;
            // SurgeryKey일 때
            case KEY.SurgeryKey:
                surgeryDoor = _collider.gameObject.GetComponent<SurgeryDoor>();
                surgeryDoor?.DoorUnlock();
                break;
        }
    }
}