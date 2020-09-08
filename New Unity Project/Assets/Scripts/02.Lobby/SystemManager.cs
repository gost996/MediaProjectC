﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [HideInInspector] public StatusViewSystem svSystem;
    [HideInInspector] public TextEffectSystem teSystem;
    
    private static SystemManager _instance;
    public static SystemManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(SystemManager)) as SystemManager;
                if (_instance == null) Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);

        svSystem = GetComponent<StatusViewSystem>();
        teSystem = GetComponent<TextEffectSystem>();
    }

}
