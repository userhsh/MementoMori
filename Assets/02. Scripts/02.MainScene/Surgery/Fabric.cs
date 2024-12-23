using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabric : MonoBehaviour, IUseable
{
    // 약품 담을 변수 선언
    Medicine medicine = null;

    private bool isUse = false;

    private Scalpel scalpel;

    private void Awake()
    {
        scalpel = GetComponent<Scalpel>();
    }

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
            // _collider로 medicine 가져오기
            medicine = _collider.gameObject.GetComponent<Medicine>();
            // medicine이 없다면 
            if (medicine == null)
            {
                // 메서드 빠져나오기
                return;
            }
            // medicine이 존재한다면 Interact 실행
            medicine?.Interact();
        }
    }
}