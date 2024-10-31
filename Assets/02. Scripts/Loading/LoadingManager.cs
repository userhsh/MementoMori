using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    string nextSceneName = null;

    public Image loadingBar;


    public void Start()
    {
        loadingBar.fillAmount = 0;

        CheckNextScene();

        StartCoroutine(LoadingScene());
    }

    private void CheckNextScene()
    {
        if (GameManager.Instance.isTutorial)
        {
            nextSceneName = "TTScene";
        }
        else
        {
            nextSceneName = "MainScene";
        }
    }

    IEnumerator LoadingScene()
    {
        yield return null;
        // 비동기 형식으로 씬 로드
        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);

        op.allowSceneActivation = false;

        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, op.progress, timer);

                if (loadingBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1f, timer);

                if (loadingBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private void GetNextSceneName()
    {

    }
}