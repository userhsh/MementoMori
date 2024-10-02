using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour, IUseable
{
    // 베개를 담을 변수 선언
    Pillow pillow = null;
    // 인형을 담을 변수 선언
    //Doll doll = null;

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
        // _collider로 베개 가져오기
        pillow = _collider.gameObject.GetComponent<Pillow>();
        // 베개를 못 가져왔을 경우
        if (pillow == null)
        {
            // 메서드 빠져나오기
            return;
        }
        // 베개가 있을 경우 Interact 실행
        pillow?.Interact();

        // _collider로 인형 가져오기
        //doll = _collider.gameObject.GetComponent<Doll>();
        // 인형을 못 가져왔을 경우
        //if (doll == null)
        //{
        //    // 메서드 빠져나오기
        //    return;
        //}
        // 인형이 있을 경우 Interact 실행
        //doll?.Interact();
    }
}