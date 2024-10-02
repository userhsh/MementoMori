using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterButton : MonoBehaviour, IUseable
{
    // 버튼 홈 가져올 변수 선언
    ButtonHole buttonHole = null;

    // 디버그 용
    private void OnTriggerEnter(Collider other)
    {
        Use(other);
    }

    public void GetItem(Transform _pos)
    {
        transform.SetParent(_pos);
        transform.position = _pos.position;
    }

    public void Use(Collider _collider)
    {
        // _collider로 ButtonHole 가져오기
        buttonHole = _collider.GetComponent<ButtonHole>();
        // 만약 버튼 홀을 가져오지 못했다면
        if (buttonHole == null ) 
        {
            // 빠져나오기
            return;
        }
        // 버튼홀이 null이 아니면 Interact 실행
        buttonHole?.Interact();
        // 버튼 없애 주기
        Destroy(this.gameObject);
    }
}