using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public bool isPause = false;

    private static PauseSystem _instance;
        public static PauseSystem Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(PauseSystem)) as PauseSystem;
                if (_instance == null) Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null) _instance = this;
        else if (_instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void Pause()
    {
        isPause = !isPause;
        Debug.Log(isPause);
    }
}
