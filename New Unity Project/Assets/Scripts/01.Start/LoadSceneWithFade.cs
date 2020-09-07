using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneWithFade : LoadScene
{
    [Header("Setting")]
    public float fadeTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartCoroutine(LoadNextScene());
    }

    protected override IEnumerator LoadNextScene()
    {
        Image c = gameObject.GetComponent<Image>();
        Color tempColor = c.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            c.color = tempColor;
            if (tempColor.a >= 1f) tempColor.a = 1f;
            yield return null;
        }
        c.color = tempColor;
        SceneManager.LoadScene(nextScene);
    }
}
