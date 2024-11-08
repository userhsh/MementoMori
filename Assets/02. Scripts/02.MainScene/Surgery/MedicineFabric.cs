using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineFabric : MonoBehaviour, IUseable
{
    // 거울 담을 변수 선언
    Mirror mirror = null;

    private bool isUse = false;

    public void GetItem(Transform _pos)
    {
        transform.SetParent(_pos);
        transform.position = _pos.position;
    }

    // 디버그 용
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 1 >> 8)
        {
            isUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 1 >> 8)
        {
            isUse = false;
        }
    }

    public void Use(Collider _collider)
    {
        if (isUse)
        {
            // _collider로 mirror를 가져오기
            mirror = _collider.gameObject.GetComponent<Mirror>();
            // mirror가 없을 경우
            if (mirror == null)
            {
                // 메서드 빠져나오기
                return;
            }
            // mirror가 존재하면 Interact 실행
            mirror?.Interact();
        }
    }
}