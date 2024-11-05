using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterHuman : MonoBehaviour, IInteractable
{
    // SlidePuzzle ���� ���� ����
    SlidePuzzle slidePuzzle = null;
    // �ݰ� ���� ���� ����
    public SafeBox safeBox = null;
    private Collider collider;
    private AudioSource audioSource;
    private AudioClip PuzzleShuffleSound;
    private AudioClip PuzzleMoveSound;
    private AudioClip CorrectSound;
    private bool puzzleClear = false;

    private void Awake()
    {
        PosterHumanInit();
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        PuzzleShuffleSound = Resources.Load<AudioClip>("SurgerySFX/PuzzleShuffleSound");
        PuzzleMoveSound = Resources.Load<AudioClip>("SurgerySFX/PuzzleMoveSound");
        CorrectSound = Resources.Load<AudioClip>("SurgerySFX/CorrectSound");
    }

    private void Update()
    {
        PuzzleClear();
    }

    // ��ü������ Init �޼���
    private void PosterHumanInit()
    {
        // �����̵� ���� ��������
        slidePuzzle = GetComponentInChildren<SlidePuzzle>();
        // �����̵� ���� ���� Init ���ֱ�
        slidePuzzle.BoardInit();
        // �����̵� ���� ���α�
        slidePuzzle.gameObject.SetActive(false);
        // �ݰ� ���α�
        safeBox.gameObject.SetActive(false);
    }

    public void Interact()
    {
        // Slide Puzzle �ѱ�
        slidePuzzle.gameObject.SetActive(true);
        audioSource.PlayOneShot(PuzzleShuffleSound);
        collider.enabled = false;
    }

    // ���� �Ϸ� �� ��ü������ ���� �޼���
    private void PuzzleClear()
    {
        // ������ Ŭ���� �Ǿ��ٸ�
        if (slidePuzzle.Board.IsPuzzleClear)
        {
            if (!puzzleClear)
            {
                audioSource.volume = 0.25f;
                audioSource.PlayOneShot(CorrectSound);
            }
            puzzleClear = true;
            // ��ü������, ���� ����
            Destroy(this.gameObject, CorrectSound.length);
            // �ݰ� ����
            safeBox.gameObject.SetActive(true);
        }
    }

    // X ��ư���� �����̵� ���� off �޼���
    private void OffSlidePuzzle()
    {
        slidePuzzle?.gameObject.SetActive(false);
    }

    public void PlayPuzzleMoveSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(PuzzleMoveSound);
        }
    }
}