using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1.0f;  // Skybox가 회전하는 속도

    private void Update()
    {
        // Skybox의 _Rotation 속성을 업데이트하여 회전
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}