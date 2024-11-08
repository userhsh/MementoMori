using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    bool clipEquit = false;
    public GameObject gunCylinder;
    private AudioSource audioSource;
    private AudioClip ReloadSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ReloadSound = Resources.Load<AudioClip>("TutorialSFX/ReloadSound/ReloadSound");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Gun")
        {
            clipEquit = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Gun")
        {
            clipEquit = false;
        }
    }

    public void GunReload()
    {
        if (clipEquit == true)
        {
            if (GameObject.Find("Gun") == null) return;

            gunCylinder.gameObject.SetActive(true); //총의 실린더에 총알 활성
            GameObject.Find("Gun").GetComponent<Gun>().foolAmmo = true; //총알이 있다고 판단하는 bool값
            GameObject.Find("Gun").name = "GunAmmo";
            audioSource.clip = ReloadSound;
            audioSource.Play();
            Invoke("DisableAmmo", ReloadSound.length);
        }
    }

    public AudioClip GetReloadSound()
    {
        return ReloadSound;
    }

    private void DisableAmmo()
    {
        gameObject.SetActive(false);
    }
}
