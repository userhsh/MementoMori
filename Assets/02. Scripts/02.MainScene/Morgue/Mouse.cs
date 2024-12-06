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
            print("츄르릅");
            if (ramenDieCount > 3f)
            {
                Destroy(other.gameObject);
                print("사망");
                GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0.3f;
                StartCoroutine(RamenDie());
            }
        }

        if (other.gameObject.name == "SmokeDieZone")
        {
            smokeDieCount += Time.deltaTime; 
            GameObject.Find("Player").GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0.3f;
            print("콜록콜록");
            if (smokeDieCount > 5f)
            {
                other.gameObject.name = "DieZone";
                print("사망");    
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


    public IEnumerator RamenDie() //게임중 죽었을 때 이벤트
    {
        yield return new WaitForSeconds(2f); //사망시작용
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
        cameraOffset.AddComponent<SphereCollider>();
        cameraOffset.GetComponent<SphereCollider>().radius = 0.06f;
        cameraOffset.AddComponent<Rigidbody>();
        cameraOffset.GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("FadeIMG").GetComponent<Animator>().SetBool("Die", true);
        GameObject.Find("FadeIMG (1)").GetComponent<Animator>().SetBool("Die", true);
        //
        yield return new WaitForSeconds(6f); //사망후 눈 감긴 뒤 플레이어를 지하로 이동
        GameObject.Find("Player").gameObject.transform.position = new Vector3(0, -9, 0);
        dieUI.gameObject.SetActive(true);
        GameObject.Find("UiFadeOut").SetActive(false);
        //
        yield return new WaitForSeconds(4f); //DIE 로고 보여준 후 게임시작씬으로 이동       
        SceneManager.LoadScene("GameStartScene");

        yield break;
    }

    public IEnumerator SmokeDie() //게임중 죽었을 때 이벤트
    {
        //사망시작용
        GameObject.Find("Left Controller").SetActive(false);
        GameObject.Find("Right Controller").SetActive(false);
        cameraOffset.AddComponent<SphereCollider>();
        cameraOffset.GetComponent<SphereCollider>().radius = 0.06f;
        cameraOffset.AddComponent<Rigidbody>();
        cameraOffset.GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("FadeIMG").GetComponent<Animator>().SetBool("Die", true);
        GameObject.Find("FadeIMG (1)").GetComponent<Animator>().SetBool("Die", true);
        //
        yield return new WaitForSeconds(6f); //사망후 눈 감긴 뒤 플레이어를 지하로 이동
        GameObject.Find("Player").gameObject.transform.position = new Vector3(0, -9, 0);
        dieUI.gameObject.SetActive(true);
        GameObject.Find("UiFadeOut").SetActive(false);
        //
        yield return new WaitForSeconds(4f); //DIE 로고 보여준 후 게임시작씬으로 이동       
        SceneManager.LoadScene("GameStartScene");

        yield break;
    }
}
