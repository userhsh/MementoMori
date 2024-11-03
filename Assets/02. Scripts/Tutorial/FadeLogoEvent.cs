using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLogoEvent : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip strongWind;
    TLeftController TleftController;
    MainmenuButtons mainmenuButtons;
    public MainmenuButtons MainmenuButtons;

    private void Awake()
    {
        mainmenuButtons = GetComponent<MainmenuButtons>();
        TleftController = GameObject.FindWithTag("PLAYER").GetComponentInChildren<TLeftController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        strongWind = Resources.Load<AudioClip>("TutorialSFX/WindSound/strongWind");
    }

    public void Warp() //�ӽ������� Ŭ������� �̵�, ��Ʈ�ѷ� ǥ��X
    {
        GameObject.Find("Player").transform.position = new Vector3(0, -1.5f, 0);
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
        audioSource.PlayOneShot(strongWind);
        StartCoroutine(StopSoundAfterDuration(6f));
    }

    public void NextScene()
    {
        TleftController.RemoveEvent(); //��� ����
        GameManager.Instance.isTutorial = false;

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.StartNewGame(); // �� ���� ���� �޼ҵ� ȣ��

        }
        else
        {
            Debug.LogError("GameManager�� ã�� �� �����ϴ�!"); // GameManager�� ���� ��� ���� �α� ���
        }

        SceneManager.LoadScene("LoadingScene");
    }

    private IEnumerator StopSoundAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
    }
}
