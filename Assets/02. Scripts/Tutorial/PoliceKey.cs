using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PoliceKey : MonoBehaviour
{
    private MeshRenderer childRenderer;
    private AudioSource audioSource;
    private AudioClip unlockSound;
    private Collider collider;
    private Rigidbody rigidbody;
    public bool use = false;

    private void Awake()
    {
        childRenderer = GetComponentInChildren<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        unlockSound = Resources.Load<AudioClip>("TutorialSFX/UnlockSound/unlockSound");
    }

    public void FirstGripKey()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.gameObject.transform.SetParent(null);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    private void OnTriggerEnter(Collider other) //열쇠와 자물쇠가 충돌 시 사용 조건 가능
    {
        if (other.gameObject.name == "PoliceDoorLock")
        {
            use = true;
        }
    }
    private void OnTriggerExit(Collider other) //열쇠와 자물쇠가 충돌을 벗어날 시 사용 조건 불가능
    {
        if (other.gameObject.name == "PoliceDoorLock")
        {
            use = false;
        }
    }

    public void PoliceDoorOpen()
    {
        if (use == true)
        {
            GameObject.Find("PoliceDoor").GetComponent<PoliceDoor>().policeDoorLock = false;
            audioSource.PlayOneShot(unlockSound);
            collider.enabled = false;
            childRenderer.enabled = false;
        }
    }
}
