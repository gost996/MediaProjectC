using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneWithLoading : LoadScene
{
    [Header("Loading UI")]
    public GameObject loadingPannel;
    public Slider loadingBar;
    public Text loadingText;

    [Header("Time Control")]
    public float limitTime;
    public float delayTime;
    private float currentTime = 0.0f;

    public void LoadingWithClick()
    {
        StartCoroutine(LoadNextScene());
    }

    protected override IEnumerator LoadNextScene()
    {
        loadingPannel.gameObject.SetActive(true);
        SystemManager.Instance.teSystem.StartCoroutine(SystemManager.Instance.teSystem.DotTypingEffect(loadingText.text, 0)); 

        /* AsyncOperation asyncOp = SceneManager.LoadSceneAsync(nextScene);
         loadingBar.value = asyncOp.progress;
         while (!asyncOp.isDone) yield return null; // 실제 로딩창 기능   */

        while (currentTime < limitTime) // 보여주기용 로딩창 기능
        {
            Debug.Log(currentTime + " " + limitTime);
            currentTime += delayTime;
            loadingBar.value += delayTime/limitTime;
            yield return new WaitForSeconds(delayTime);
        }
        SceneManager.LoadScene(nextScene);
    }
}
