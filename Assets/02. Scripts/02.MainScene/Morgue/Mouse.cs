using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Mouse : MonoBehaviour
{
    GameObject cameraOffset;
    public GameObject dieUI;
    public AudioClip[] audioClips;
    AudioSource audioSource;

    bool coughingStart = false;
    bool noodleStart = false;

    float smokeDieCount = 0;
    float ramenDieCount = 0;

    private void Awake()
    {
        cameraOffset = GameObject.Find("Camera Offset");
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ramen")
        {
            ramenDieCount += Time.deltaTime;
            print("�򸣸�");

            StartCoroutine(NoodleSound());

            if (ramenDieCount > 3f)
            {
                Destroy(other.gameObject);
                print("���");
                GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0.3f;
                StartCoroutine(RamenDie());
            }
        }

        if (other.gameObject.name == "SmokeDieZone")
        {
            smokeDieCount += Time.deltaTime;
            GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0.3f;
            print("�ݷ��ݷ�");

            StartCoroutine(CoughingSound());

            if (smokeDieCount > 5f)
            {
                other.gameObject.name = "DieZone";
                print("���");
                StartCoroutine(SmokeDie());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ramen")
        {
            //
            coughingCount = 0;
        }

        if (other.gameObject.name == "SmokeDieZone")
        {
            GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 2f;
            smokeDieCount = 0f;
            coughingCount = 0;
        }


    }

    bool soundable = true;
    int coughingCount = 0;

    IEnumerator CoughingSound()
    {
        if (!soundable) yield break;

        soundable = false;

        if (audioSource.isPlaying)
        {
            yield return null;
        }
        else
        {
            if (coughingCount != 0)
            {
                yield return new WaitForSeconds(0.5f);
            }
            audioSource.clip = audioClips[1];
            audioSource.Play();
            coughingCount++;
        }

        soundable = true;
    }

    IEnumerator NoodleSound()
    {
        if (!soundable) yield break;

        soundable = false;

        if (audioSource.isPlaying)
        {
            yield return null;
        }
        else
        {
            if (coughingCount != 0)
            {
                yield return new WaitForSeconds(0.5f);
            }
            audioSource.clip = audioClips[0];
            audioSource.Play();
            coughingCount++;
        }

        soundable = true;
    }

    public IEnumerator RamenDie() //������ �׾��� �� �̺�Ʈ
    {
        yield return new WaitForSeconds(2f); //������ۿ�
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
        cameraOffset.AddComponent<SphereCollider>();
        cameraOffset.GetComponent<SphereCollider>().radius = 0.06f;
        cameraOffset.AddComponent<Rigidbody>();
        cameraOffset.GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("FadeIMG").GetComponent<Animator>().SetBool("Die", true);
        GameObject.Find("FadeIMG (1)").GetComponent<Animator>().SetBool("Die", true);
        //
        yield return new WaitForSeconds(6f); //����� �� ���� �� �÷��̾ ���Ϸ� �̵�
        GameObject.Find("Player").gameObject.transform.position = new Vector3(0, -9, 0);
        audioSource.clip = audioClips[2];
        audioSource.Play();
        dieUI.gameObject.SetActive(true);
        GameObject.Find("UiFadeOut").SetActive(false);
        //
        yield return new WaitForSeconds(4f); //DIE �ΰ� ������ �� ���ӽ��۾����� �̵�       
        SceneManager.LoadScene("GameStartScene");

        yield break;
    }

    public IEnumerator SmokeDie() //������ �׾��� �� �̺�Ʈ
    {
        //������ۿ�
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
        cameraOffset.AddComponent<SphereCollider>();
        cameraOffset.GetComponent<SphereCollider>().radius = 0.06f;
        cameraOffset.AddComponent<Rigidbody>();
        cameraOffset.GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("FadeIMG").GetComponent<Animator>().SetBool("Die", true);
        GameObject.Find("FadeIMG (1)").GetComponent<Animator>().SetBool("Die", true);
        //
        yield return new WaitForSeconds(6f); //����� �� ���� �� �÷��̾ ���Ϸ� �̵�
        GameObject.Find("Player").gameObject.transform.position = new Vector3(0, -9, 0);
        audioSource.clip = audioClips[2];
        audioSource.Play();
        dieUI.gameObject.SetActive(true);
        GameObject.Find("UiFadeOut").SetActive(false);
        //
        yield return new WaitForSeconds(4f); //DIE �ΰ� ������ �� ���ӽ��۾����� �̵�       
        SceneManager.LoadScene("GameStartScene");

        yield break;
    }
}
