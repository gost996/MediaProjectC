using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class LoadScene : MonoBehaviour
{
    [Header("Load Setting")]
    protected string nextScene = "Ingame_Colosseum";

    protected virtual IEnumerator LoadNextScene()
    {
        yield return null;
    }

    public void SetNextScene(string sceneName)
    {
        nextScene = sceneName;
    }
}
