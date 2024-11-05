using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlidePuzzleBoard : MonoBehaviour
{
    // �����̵� ���� Ÿ�ϵ� ���� ���� ����
    SlidePuzzleTile[] tiles;

    // Inversions ����� ���� ����
    private int inversions = 0;
    // Ÿ�� �迭�� �ε����� ���� ���� ����
    private int tileIndex = 0;
    // Ÿ�� ������ �Ÿ� 0.97
    private float tileDistance = 0.58f;
    // ������ �� �� �ִ��� Ȯ���� ���� ����
    private bool isClearable = false;
    // isClearable�� ������Ƽ (get�� ������)
    public bool IsClearable { get { return isClearable; } }
    // ������ Ŭ�����ߴ��� Ȯ���ϴ� ���� ����
    public bool isPuzzleClear;
    // isPuzzleClear�� ������Ƽ
    public bool IsPuzzleClear { get { return isPuzzleClear; } }

    // �� Ÿ���� ��ġ�� ���� ���� ����
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

    // �����̵� ���� ���� Init �޼���
    private void SlidePuzzleBoardInit()
    {
        // Ÿ�ϵ� ��������
        tiles = GetComponentsInChildren<SlidePuzzleTile>();
        isPuzzleClear = false;
        TileInit();
    }

    // Ÿ�� Init �޼���
    private void TileInit()
    {
        // tiles �������ֱ�
        for (int i = 0; i < tiles.Length; i++)
        {
            // Ÿ���� �� ����
            tiles[i].TileValue = i;
        }
    }

    // Ÿ���� �������� ���� �ڷ�ƾ
    IEnumerator OnShuffle()
    {
        // Ÿ���� ���� �ð��� ���������� �ð�
        float currentTime = 0;
        // Ÿ���� ���� �ð� 1.5��
        float shuffleTime = 1.5f;
        // Ÿ���� ���� ������ �ð� ���� ���ݱ����� �ð� ����
        float percent = 0;

        // percent�� 1���� ���� ���(= Ÿ���� ���� ������ �ð��� 1.5�ʰ� ������ �ʾ��� ���
        while (percent < 1)
        {
            // currentTime�� Time.deltaTime��ŭ ����
            currentTime += Time.deltaTime;
            // ���� ���
            percent = currentTime / shuffleTime;

            // ���� Ÿ���� �ε��� ��������
            tileIndex = Random.Range(0, tiles.Length);
            // ������ �ε����� Ÿ���� �迭�� ������ ������
            tiles[tileIndex].transform.SetAsLastSibling();

            yield return null;
        }

        // ���õ� Ÿ���� Inversions ����ؼ� Ŭ���� ���� �Ǵ��ϱ�
        InversionsCalCulation();

        // �ٽ� Ÿ�� ����
        StartCoroutine(ReShuffleTile());

        // ���� Ŭ���� Ȯ���ϱ�
        StartCoroutine(PuzzleInversionsCheck());
    }

    // Inversions ��� �޼���
    // 3 * 3 �����̵� ������ ��� inversions�� ¦���� ��� Ŭ���� ����
    private void InversionsCalCulation()
    {
        // Ÿ�� �迭 null�� �ʱ�ȭ
        tiles = null;
        // ���� Ÿ�Ϸ� �迭 �ٽ� ��������
        tiles = GetComponentsInChildren<SlidePuzzleTile>();

        // inversions ��� 
        // i�� 0���� ������
        for (int i = 0; i < tiles.Length; i++)
        {
            // j�� i + 1���� ������
            for (int j = i + 1; j < tiles.Length; j++)
            {
                // tiles[i].TileValue�� tiles[j].TileValue�� ��
                // tiles[i].TileValue�� tiles[j].TileValue���� Ŭ ���(= �տ� �ִ� ���� �ڿ� �ִ� ������ Ŭ ���)
                if (tiles[i].TileValue > tiles[j].TileValue)
                {
                    // inversions 1 ����
                    inversions++;
                }
            }
        }

        // inversions�� ¦���̰� 0�� �ƴ� ���
        if (inversions % 2 == 0 && inversions != 0)
        {
            // Ŭ���� ����
            isClearable = true;
        }
        // inversions�� Ȧ���̰ų� 0�� ���
        else
        {
            // Ŭ���� �Ұ�
            isClearable = false;
        }
    }

    // ����� �ڷ�ƾ
    IEnumerator ReShuffleTile()
    {
        // Ŭ��� �Ұ����ϴٸ�
        while (!isClearable)
        {
            // Ÿ�� �ε��� �������� ��������
            tileIndex = Random.Range(0, tiles.Length);
            // ������ Ÿ�� ������ ������
            tiles[tileIndex].transform.SetAsLastSibling();
            // ���� inversions Ȯ���ؼ� Ŭ���� ���� �Ǵ��ϱ�
            InversionsCalCulation();

            // 0.1�ʰ� ��� (�ٽ� ���� ���� õõ�� ���� ����)
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Ÿ�� �̵� �޼���
    public void MoveTile(SlidePuzzleTile _tile)
    {
        // ������ Ŭ���� �� �� ���ٸ� ���ư���
        if (!isClearable) return;

        // ���õ� Ÿ���� ��ġ ��������
        Vector3 selectTilePosition = _tile.GetComponent<RectTransform>().localPosition;

        // �� Ÿ���� ��ġ ��������
        foreach (var tile in tiles)
        {
            if (tile.TileValue == 8)
            {
                emptyTilePosition = tile.GetComponent<RectTransform>().localPosition;
            }
        }

        // �� Ÿ�ϰ� ������ Ÿ���� �Ÿ��� ���
        // ���� ����� tileDistance �̳����
        if (Vector3.Distance(emptyTilePosition, selectTilePosition) <= tileDistance)
        {
            // Ÿ���� ��ǥ ���� �ٲ��ֱ�
            Vector3 tempPosition = emptyTilePosition;
            emptyTilePosition = selectTilePosition;
            selectTilePosition = tempPosition;

            // �� Ÿ�� ��ġ �̵�
            foreach (var tile in tiles)
            {
                if (tile.TileValue == 8)
                {
                    tile.GetComponent<RectTransform>().localPosition = emptyTilePosition;
                }
            }

            // ������ Ÿ�� ��ġ �̵�
            _tile.GetComponent<RectTransform>().localPosition = selectTilePosition;
        }

        posterHuman.PlayPuzzleMoveSound();
    }

    // ���� Ŭ���� Ȯ�� �ڷ�ƾ
    IEnumerator PuzzleInversionsCheck()
    {
        // Ŭ���� ���� �ʾ��� ��� �ݺ�
        while (!isPuzzleClear)
        {
            // ���� ��ġ�� ���ƿ� Ÿ���� ���� Ȯ���� ���� ���� (��� 0���� �ʱ�ȭ)
            int correctCount = 0;

            // ��� Ÿ�Ͽ� ���ؼ�
            foreach (var tile in tiles)
            {
                // ���� ��ġ�� ���� ��ġ�� ������ Ȯ��
                // ���� ���
                if (tile.GetComponent<RectTransform>().localPosition == tile.correctPosition)
                {
                    // Ÿ���� IsCorrect�� true��
                    tile.IsCorrect = true;
                }
                // �ƴ� ���
                else
                {
                    // Ÿ���� IsCorrect�� false��
                    tile.IsCorrect = false;
                }

                // Ÿ���� IsCorrect�� true�� �͵鸸
                if (tile.IsCorrect)
                {
                    // correctCount 1�� ����
                    correctCount++;
                }
            }

            // ��� Ÿ���� ��ġ�� ó���� �����ϴٸ�
            if (correctCount == 9)
            {
                // ������ Ŭ���� ���·� ����
                isPuzzleClear = true;
            }

            yield return null;
        }
    }
}