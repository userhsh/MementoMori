using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtDiary : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip collectionSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        this.gameObject.name = "Collection3";
        collectionSound = Resources.Load<AudioClip>("SurgerySFX/collectionSound");
    }
    public void Collection3Get()
    {
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collections[2] = true;
        GameObject.Find("PlayerUI").GetComponent<UIManager>().collectTalkCount++;
        GameObject.Find("PlayerUI").GetComponent<UIManager>().CollectGetTalkCount();

        audioSource.PlayOneShot(collectionSound);
        Invoke("DeactivateDiary", collectionSound.length);
    }

    private void DeactivateDiary()
    {
        this.gameObject.SetActive(false);
    }

}
