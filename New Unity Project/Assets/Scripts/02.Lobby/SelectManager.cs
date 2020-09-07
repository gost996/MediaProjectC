using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [Header("lCharacterList")]
    public GameObject CharacterList;
    [HideInInspector] public List<GameObject> selectPC = new List<GameObject>();
    [HideInInspector] public GameObject nowCharacter;
    [HideInInspector] public StatusView sv;
    private Quaternion standardRT;
    private static SelectManager _instance;

    public static SelectManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(SelectManager)) as SelectManager;
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

        sv = GetComponent<StatusView>();

        for (int i = 0; i < CharacterList.transform.childCount; i++) selectPC.Add(CharacterList.transform.GetChild(i).gameObject);
        selectPC[0].SetActive(true);
        nowCharacter = selectPC[0];
        RotateCharacter.Instance.SetRotateCharacter(nowCharacter);
        standardRT = selectPC[0].GetComponent<Transform>().rotation;
        sv.SetlCharacter(nowCharacter.GetComponent<lCharacter>());
    }

    public void SetCharacter(int i)
    {
        nowCharacter.SetActive(false);
        GameObject _pc;
        _pc = selectPC[i];
        _pc.GetComponent<Transform>().rotation = standardRT;
        _pc.SetActive(true);
        nowCharacter = _pc;
        RotateCharacter.Instance.SetRotateCharacter(nowCharacter);
        sv.SetlCharacter(nowCharacter.GetComponent<lCharacter>());
    }
}
