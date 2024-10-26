using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1.0f;  // Skybox�� ȸ���ϴ� �ӵ�

    private void Update()
    {
        // Skybox�� _Rotation �Ӽ��� ������Ʈ�Ͽ� ȸ��
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}