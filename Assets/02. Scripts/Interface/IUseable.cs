using UnityEngine;

public interface IUseable
{
    // 아이템 획득 (Transform 변수를 인자로 받아서 사용)
    public void GetItem(Transform _pos);
    // 아이템 사용 (Collider 변수를 인자로 받아서 사용)
    public void Use(Collider _collider);
}