using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioClip footstepSound;    // 발소리 클립
    private float stepInterval = 0.65f;  // 발소리 간격
    private float minMoveThreshold = 0.1f;  // 발소리가 나기 위한 최소 입력 값

    private AudioSource audioSource;
    private ActionBasedContinuousMoveProvider moveProvider;  // Continuous Move Provider 참조
    private bool isPlayingFootsteps = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        moveProvider = GetComponent<ActionBasedContinuousMoveProvider>();  // 이동 제공자 참조
    }

    private void Start()
    {
        footstepSound = Resources.Load<AudioClip>("PlayerSFX/FootstepSound/footstepSound");
    }

    private void Update()
    {
        // 이동 입력 값을 읽어옴
        Vector2 moveInput = moveProvider.leftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
        moveInput += moveProvider.rightHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

        // 입력 값이 최소 임계값보다 클 경우에만 발소리 재생
        if (moveInput.magnitude > minMoveThreshold && !isPlayingFootsteps)
        {
            StartCoroutine(PlayFootsteps());
        }
        else if (moveInput.magnitude <= minMoveThreshold)
        {
            StopAllCoroutines();
            isPlayingFootsteps = false;
        }
    }

    // 발소리를 반복해서 재생하는 코루틴
    private IEnumerator PlayFootsteps()
    {
        isPlayingFootsteps = true;

        while (true)
        {
            audioSource.PlayOneShot(footstepSound);  // 발소리 재생
            yield return new WaitForSeconds(stepInterval);  // 발소리 간격 대기
        }
    }
}