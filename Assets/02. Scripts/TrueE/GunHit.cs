using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GunHit : MonoBehaviour
{

    private Transform shakeCamera;
    private Image bloodImage;
    private AudioClip shotClip;
    private AudioSource shotSource;
    private TextMeshProUGUI endText = null;

    Vector3 originPos;
    Quaternion originRot;

    private bool shakeRotate = false;
    private float bloodDuration = 0.5f; // 피 효과 시간

    private void Awake()
    {

        shakeCamera = GetComponentInChildren<Camera>().transform;
        bloodImage = GetComponentInChildren<Image>();
        endText = GetComponentInChildren<TextMeshProUGUI>();
        shotSource = GetComponent<AudioSource>();
        shotClip = Resources.Load<AudioClip>("OfficeSFX/shotClip");
        
        //흔들기 전 원래 위치값과 회전값 
        originPos = shakeCamera.localPosition;
        originRot = shakeCamera.localRotation;

        // 스크립트가 시작될 때 피 이미지가 보이지 않도록
        bloodImage.gameObject.SetActive(false);
        endText.gameObject.SetActive(false);
    }

    // 총에 맞았을 때 호출되는 메서드
    public IEnumerator ShakeCamera(float duration = 0.2f, float magnitudePos = 0.5f, float magnitudeRot = 0.1f)
    {

        print("1");

        shotSource.PlayOneShot(shotClip);
        float passTime = 0f;

        //duration 동안 흔들기 위해서 while
        while (passTime < duration)
        {
            //반지름이 1인 구형의 공간 안에서 랜덤한 3개의 좌표(x,y,z) 추출
            Vector3 shakePos = Random.insideUnitSphere;

            //위에서 뽑은 랜덤위치와 매개변수 통해서 흔들기
            shakeCamera.localPosition = shakePos * magnitudePos;

            //불규칙한 회전 사용 유무
            if (shakeRotate)
            {
                //수학의 펄린노이즈 함수, 어떤 불규칙한 패턴, 랜덤 맵 생성 등...
                float z = Mathf.PerlinNoise(Time.time * magnitudeRot, 0f);
                Vector3 shakeRot = new Vector3(0, 0, z);

                shakeCamera.localRotation = Quaternion.Euler(shakeRot);
            }

            passTime += Time.deltaTime;
            yield return null;

        }

        shakeCamera.localPosition = originPos;
        shakeCamera.localRotation = originRot;

    }


    public IEnumerator ShowBloodEffect()
    {
        print("2");
        // 피 이미지 활성화
        bloodImage.gameObject.SetActive(true);
        float elapsed = 0f; // 경과 시간


        while (elapsed < bloodDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / bloodDuration); // 1에서 0으로
            bloodImage.color = new Color(1, 0, 0, alpha);

            elapsed += Time.deltaTime;
            yield return null; 
        }

        
        // 피 비활성화
        bloodImage.gameObject.SetActive(false);
        Invoke("ShowEndText", 5f);
    }

    private void ShowEndText()
    {
        print("3");
        endText.gameObject.SetActive(true);

        Invoke("BackToStart", 5f);

    }

    private void BackToStart()
    {
        print("4");
        SceneManager.LoadScene("GameStartScene");
    }
}
