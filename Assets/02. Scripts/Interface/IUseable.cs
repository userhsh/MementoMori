using UnityEngine;

public interface IUseable
{
    // 아이템 획득
    public void GetItem(Transform _pos);
    // 아이템 사용
    public void Use(Collider _collider);
}