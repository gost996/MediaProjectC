using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneWithLoading : LoadScene
{
    public GameObject loadingPannel;
    public Slider loadingBar;
    
    public void LoadingWithClick()
    {
        StartCoroutine(LoadNextScene());
    }

    protected override IEnumerator LoadNextScene()
    {
        loadingPannel.gameObject.SetActive(true);
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(nextScene);
        loadingBar.value = asyncOp.progress;
        while (!asyncOp.isDone) yield return null;
    }
}
