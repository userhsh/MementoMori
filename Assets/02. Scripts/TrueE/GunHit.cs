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
    private float bloodDuration = 0.5f; // �� ȿ�� �ð�

    private void Awake()
    {

        shakeCamera = GetComponentInChildren<Camera>().transform;
        bloodImage = GetComponentInChildren<Image>();
        endText = GetComponentInChildren<TextMeshProUGUI>();
        shotSource = GetComponent<AudioSource>();
        shotClip = Resources.Load<AudioClip>("OfficeSFX/shotClip");
        
        //���� �� ���� ��ġ���� ȸ���� 
        originPos = shakeCamera.localPosition;
        originRot = shakeCamera.localRotation;

        // ��ũ��Ʈ�� ���۵� �� �� �̹����� ������ �ʵ���
        bloodImage.gameObject.SetActive(false);
        endText.gameObject.SetActive(false);
    }

    // �ѿ� �¾��� �� ȣ��Ǵ� �޼���
    public IEnumerator ShakeCamera(float duration = 0.2f, float magnitudePos = 0.5f, float magnitudeRot = 0.1f)
    {

        print("1");

        shotSource.PlayOneShot(shotClip);
        float passTime = 0f;

        //duration ���� ���� ���ؼ� while
        while (passTime < duration)
        {
            //�������� 1�� ������ ���� �ȿ��� ������ 3���� ��ǥ(x,y,z) ����
            Vector3 shakePos = Random.insideUnitSphere;

            //������ ���� ������ġ�� �Ű����� ���ؼ� ����
            shakeCamera.localPosition = shakePos * magnitudePos;

            //�ұ�Ģ�� ȸ�� ��� ����
            if (shakeRotate)
            {
                //������ �޸������� �Լ�, � �ұ�Ģ�� ����, ���� �� ���� ��...
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
        // �� �̹��� Ȱ��ȭ
        bloodImage.gameObject.SetActive(true);
        float elapsed = 0f; // ��� �ð�


        while (elapsed < bloodDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / bloodDuration); // 1���� 0����
            bloodImage.color = new Color(1, 0, 0, alpha);

            elapsed += Time.deltaTime;
            yield return null; 
        }

        
        // �� ��Ȱ��ȭ
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
