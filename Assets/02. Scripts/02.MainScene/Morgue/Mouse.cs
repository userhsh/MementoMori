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

    float smokeDieCount = 0;
    float ramenDieCount = 0;

    private void Awake()
    {
        cameraOffset = GameObject.Find("Camera Offset");


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ramen")
        {
            ramenDieCount += Time.deltaTime;
            print("�򸣸�");
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
        if(other.gameObject.name == "SmokeDieZone")
        {
            GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 2f;
            smokeDieCount = 0f;
        }
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
        dieUI.gameObject.SetActive(true);
        GameObject.Find("UiFadeOut").SetActive(false);
        //
        yield return new WaitForSeconds(4f); //DIE �ΰ� ������ �� ���ӽ��۾����� �̵�       
        SceneManager.LoadScene("GameStartScene");

        yield break;
    }
}
