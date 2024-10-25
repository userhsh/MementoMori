using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterHuman : MonoBehaviour, IInteractable
{
    // SlidePuzzle 담을 변수 선언
    SlidePuzzle slidePuzzle = null;
    // 금고 담을 변수 선언
    public SafeBox safeBox = null;

    private void Awake()
    {
        PosterHumanInit();
    }

    private void Update()
    {
        PuzzleClear();
    }

    // 인체모형도 Init 메서드
    private void PosterHumanInit()
    {
        // 슬라이드 퍼즐 가져오기
        slidePuzzle = GetComponentInChildren<SlidePuzzle>();
        // 슬라이드 퍼즐 보드 Init 해주기
        slidePuzzle.BoardInit();
        // 슬라이드 퍼즐 꺼두기
        slidePuzzle.gameObject.SetActive(false);
        // 금고 꺼두기
        safeBox.gameObject.SetActive(false);
    }

    public void Interact()
    {
        // Slide Puzzle 켜기
        slidePuzzle.gameObject.SetActive(true);
    }

    // 퍼즐 완료 시 인체모형도 제거 메서드
    private void PuzzleClear()
    {
        // 퍼즐이 클리어 되었다면
        if (slidePuzzle.Board.IsPuzzleClear)
        {
            // 인체모형도, 퍼즐 제거
            Destroy(this.gameObject);
            // 금고 생성
            safeBox.gameObject.SetActive(true);
        }
    }

    // X 버튼으로 슬라이드 퍼즐 off 메서드
    private void OffSlidePuzzle()
    {
        slidePuzzle?.gameObject.SetActive(false);
    }
}