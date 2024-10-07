using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition;

    private XRRayInteractor[] xrRayInteractors = null;
    private XRInteractorLineVisual[] xrInteractorsLineVisuals = null;

    private IInteractable interactable = null;

    private PlayerController() { }
    private static PlayerController _instance;
    private static readonly object _lock = new object();

    public static PlayerController Instance
    {
        get
        {
            // 인스턴스가 아직 생성되지 않았다면
            if (_instance == null)
            {
                // 스레드 안전성을 위해 lock 사용
                lock (_lock)
                {
                    // 다시 한 번 확인하여 여러 스레드에서 동시에 인스턴스를 생성하지 않도록 함
                    if (_instance == null)
                    {
                        _instance = new PlayerController();
                    }
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        PlayerControllerInit();
        PlayerRayControll();
    }

    private void Start()
    {
        PlayerPositionInit(startPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        interactable = other.gameObject.GetComponent<IInteractable>();
        interactable?.Interact();
    }

    private void PlayerControllerInit()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // 인스턴스를 설정하고 이 객체를 파괴되지 않게 설정
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        xrRayInteractors = GetComponentsInChildren<XRRayInteractor>(); // [0] Left, [1] Right
        xrInteractorsLineVisuals = GetComponentsInChildren<XRInteractorLineVisual>(); // [0] Left, [1] Right
    }

    public Vector3 GetStartPosition()
    {
        startPosition = GameObject.FindGameObjectWithTag("STARTPOSITION").transform.position;
        return startPosition;
    }

    public void PlayerPositionInit(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public void PlayerRayControll()
    {
        if (SceneManager.GetActiveScene().name == "GameStartScene")
        {
            foreach (var rayDistance in xrRayInteractors) 
            {
                rayDistance.maxRaycastDistance = 200f;
            }

            foreach (var rayDistance in xrInteractorsLineVisuals)
            {
                rayDistance.lineLength = 200f;
            }
        }
        else
        {
            foreach (var rayDistance in xrRayInteractors)
            {
                rayDistance.maxRaycastDistance = 0.3f;
            }

            foreach (var rayDistance in xrInteractorsLineVisuals)
            {
                rayDistance.lineLength = 0.3f;
            }
        }
    }
}