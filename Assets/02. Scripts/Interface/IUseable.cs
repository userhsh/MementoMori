using UnityEngine;

public interface IUseable
{
    // ������ ȹ��
    public void GetItem(Transform _pos);
    // ������ ���
    public void Use(Collider _collider);
}