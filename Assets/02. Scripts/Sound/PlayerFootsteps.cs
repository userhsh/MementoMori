using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioClip footstepSound;    // �߼Ҹ� Ŭ��
    private float stepInterval = 0.65f;  // �߼Ҹ� ����
    private float minMoveThreshold = 0.1f;  // �߼Ҹ��� ���� ���� �ּ� �Է� ��

    private AudioSource audioSource;
    private ActionBasedContinuousMoveProvider moveProvider;  // Continuous Move Provider ����
    private bool isPlayingFootsteps = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        moveProvider = GetComponent<ActionBasedContinuousMoveProvider>();  // �̵� ������ ����
    }

    private void Start()
    {
        footstepSound = Resources.Load<AudioClip>("PlayerSFX/FootstepSound/footstepSound");
    }

    private void Update()
    {
        // �̵� �Է� ���� �о��
        Vector2 moveInput = moveProvider.leftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
        moveInput += moveProvider.rightHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

        // �Է� ���� �ּ� �Ӱ谪���� Ŭ ��쿡�� �߼Ҹ� ���
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

    // �߼Ҹ��� �ݺ��ؼ� ����ϴ� �ڷ�ƾ
    private IEnumerator PlayFootsteps()
    {
        isPlayingFootsteps = true;

        while (true)
        {
            audioSource.PlayOneShot(footstepSound);  // �߼Ҹ� ���
            yield return new WaitForSeconds(stepInterval);  // �߼Ҹ� ���� ���
        }
    }
}