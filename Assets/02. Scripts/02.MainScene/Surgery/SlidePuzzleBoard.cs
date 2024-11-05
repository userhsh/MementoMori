using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlidePuzzleBoard : MonoBehaviour
{
    // 슬라이드 퍼즐 타일들 담을 변수 선언
    SlidePuzzleTile[] tiles;

    // Inversions 계산할 변수 선언
    private int inversions = 0;
    // 타일 배열의 인덱스를 담을 변수 선언
    private int tileIndex = 0;
    // 타일 사이의 거리 0.97
    private float tileDistance = 0.58f;
    // 퍼즐을 깰 수 있는지 확인할 변수 선언
    private bool isClearable = false;
    // isClearable의 프로퍼티 (get만 열어줌)
    public bool IsClearable { get { return isClearable; } }
    // 퍼즐을 클리어했는지 확인하는 변수 선언
    public bool isPuzzleClear;
    // isPuzzleClear의 프로퍼티
    public bool IsPuzzleClear { get { return isPuzzleClear; } }

    // 빈 타일의 위치를 담을 변수 선언
    private Vector3 emptyTilePosition = Vector3.zero;

    private PosterHuman posterHuman;

    private void Awake()
    {
        SlidePuzzleBoardInit();
        posterHuman = FindObjectOfType<PosterHuman>();
    }

    private void OnEnable()
    {
        StartCoroutine(OnShuffle());
    }

    private void OnDisable()
    {
        StopCoroutine(OnShuffle());
    }

    // 슬라이드 퍼즐 보드 Init 메서드
    private void SlidePuzzleBoardInit()
    {
        // 타일들 가져오기
        tiles = GetComponentsInChildren<SlidePuzzleTile>();
        isPuzzleClear = false;
        TileInit();
    }

    // 타일 Init 메서드
    private void TileInit()
    {
        // tiles 설정해주기
        for (int i = 0; i < tiles.Length; i++)
        {
            // 타일의 값 설정
            tiles[i].TileValue = i;
        }
    }

    // 타일을 랜덤으로 섞는 코루틴
    IEnumerator OnShuffle()
    {
        // 타일을 섞기 시간한 시점부터의 시간
        float currentTime = 0;
        // 타일을 섞을 시간 1.5초
        float shuffleTime = 1.5f;
        // 타일을 섞기 시작한 시간 부터 지금까지의 시간 비율
        float percent = 0;

        // percent가 1보다 작을 경우(= 타일을 섞기 시작한 시간이 1.5초가 지나지 않았을 경우
        while (percent < 1)
        {
            // currentTime을 Time.deltaTime만큼 증가
            currentTime += Time.deltaTime;
            // 비율 계산
            percent = currentTime / shuffleTime;

            // 랜덤 타일의 인덱스 가져오기
            tileIndex = Random.Range(0, tiles.Length);
            // 가져온 인덱스의 타일을 배열의 끝으로 보내기
            tiles[tileIndex].transform.SetAsLastSibling();

            yield return null;
        }

        // 셔플된 타일의 Inversions 계산해서 클리어 여부 판단하기
        InversionsCalCulation();

        // 다시 타일 섞기
        StartCoroutine(ReShuffleTile());

        // 게임 클리어 확인하기
        StartCoroutine(PuzzleInversionsCheck());
    }

    // Inversions 계산 메서드
    // 3 * 3 슬라이드 퍼즐의 경우 inversions가 짝수일 경우 클리어 가능
    private void InversionsCalCulation()
    {
        // 타일 배열 null로 초기화
        tiles = null;
        // 섞인 타일로 배열 다시 가져오기
        tiles = GetComponentsInChildren<SlidePuzzleTile>();

        // inversions 계산 
        // i는 0부터 끝까지
        for (int i = 0; i < tiles.Length; i++)
        {
            // j는 i + 1부터 끝까지
            for (int j = i + 1; j < tiles.Length; j++)
            {
                // tiles[i].TileValue와 tiles[j].TileValue를 비교
                // tiles[i].TileValue가 tiles[j].TileValue보다 클 경우(= 앞에 있는 수가 뒤에 있는 수보다 클 경우)
                if (tiles[i].TileValue > tiles[j].TileValue)
                {
                    // inversions 1 증가
                    inversions++;
                }
            }
        }

        // inversions가 짝수이고 0이 아닐 경우
        if (inversions % 2 == 0 && inversions != 0)
        {
            // 클리어 가능
            isClearable = true;
        }
        // inversions가 홀수이거나 0일 경우
        else
        {
            // 클리어 불가
            isClearable = false;
        }
    }

    // 재셔플 코루틴
    IEnumerator ReShuffleTile()
    {
        // 클리어가 불가능하다면
        while (!isClearable)
        {
            // 타일 인덱스 랜덤으로 가져오기
            tileIndex = Random.Range(0, tiles.Length);
            // 가져온 타일 끝으로 보내기
            tiles[tileIndex].transform.SetAsLastSibling();
            // 퍼즐 inversions 확인해서 클리어 여부 판단하기
            InversionsCalCulation();

            // 0.1초간 대기 (다시 섞을 때는 천천히 섞기 위해)
            yield return new WaitForSeconds(0.1f);
        }
    }

    // 타일 이동 메서드
    public void MoveTile(SlidePuzzleTile _tile)
    {
        // 퍼즐을 클리어 할 수 없다면 돌아가기
        if (!isClearable) return;

        // 선택된 타일의 위치 가져오기
        Vector3 selectTilePosition = _tile.GetComponent<RectTransform>().localPosition;

        // 빈 타일의 위치 가져오기
        foreach (var tile in tiles)
        {
            if (tile.TileValue == 8)
            {
                emptyTilePosition = tile.GetComponent<RectTransform>().localPosition;
            }
        }

        // 빈 타일과 선택한 타일의 거리를 계산
        // 계산된 결과가 tileDistance 이내라면
        if (Vector3.Distance(emptyTilePosition, selectTilePosition) <= tileDistance)
        {
            // 타일의 좌표 서로 바꿔주기
            Vector3 tempPosition = emptyTilePosition;
            emptyTilePosition = selectTilePosition;
            selectTilePosition = tempPosition;

            // 빈 타일 위치 이동
            foreach (var tile in tiles)
            {
                if (tile.TileValue == 8)
                {
                    tile.GetComponent<RectTransform>().localPosition = emptyTilePosition;
                }
            }

            // 선택한 타일 위치 이동
            _tile.GetComponent<RectTransform>().localPosition = selectTilePosition;
        }

        posterHuman.PlayPuzzleMoveSound();
    }

    // 퍼즐 클리어 확인 코루틴
    IEnumerator PuzzleInversionsCheck()
    {
        // 클리어 되지 않았을 경우 반복
        while (!isPuzzleClear)
        {
            // 원래 위치로 돌아온 타일의 수를 확인할 변수 선언 (계속 0으로 초기화)
            int correctCount = 0;

            // 모든 타일에 대해서
            foreach (var tile in tiles)
            {
                // 현재 위치와 원래 위치가 같은지 확인
                // 같은 경우
                if (tile.GetComponent<RectTransform>().localPosition == tile.correctPosition)
                {
                    // 타일의 IsCorrect를 true로
                    tile.IsCorrect = true;
                }
                // 아닐 경우
                else
                {
                    // 타일의 IsCorrect를 false로
                    tile.IsCorrect = false;
                }

                // 타일의 IsCorrect가 true인 것들만
                if (tile.IsCorrect)
                {
                    // correctCount 1씩 증가
                    correctCount++;
                }
            }

            // 모든 타일의 위치가 처음과 동일하다면
            if (correctCount == 9)
            {
                // 퍼즐을 클리어 상태로 변경
                isPuzzleClear = true;
            }

            yield return null;
        }
    }
}