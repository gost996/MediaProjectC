using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class LoadScene : MonoBehaviour
{
    [Header("Load Setting")]
    public string nextScene;

    protected virtual IEnumerator LoadNextScene()
    {
        yield return null;
    }
}
