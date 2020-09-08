using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [Header("lCharacterList")]
    public GameObject CharacterList;
    [HideInInspector] public List<lCharacter> selectPC = new List<lCharacter>();
    [HideInInspector] public lCharacter nowCharacter;

    [HideInInspector] public StatusViewSystem sv;
    [HideInInspector] public TextEffectSystem te;

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

        sv = SystemManager.Instance.svSystem;
        te = SystemManager.Instance.teSystem;

        for (int i = 0; i < CharacterList.transform.childCount; i++) selectPC.Add(CharacterList.transform.GetChild(i).GetComponent<lCharacter>());

        selectPC[0].gameObject.SetActive(true);
        nowCharacter = selectPC[0];
        RotationManager.Instance.SetRotationManager(nowCharacter.gameObject);
        standardRT = selectPC[0].GetComponent<Transform>().rotation;
        sv.SetlCharacter(nowCharacter);
        te.StartCoroutine(te.TypingEffect(nowCharacter.contentText));
    }

    public void SetCharacter(int i)
    {
        nowCharacter.gameObject.SetActive(false);
        lCharacter _pc;
        _pc = selectPC[i];
        _pc.GetComponent<Transform>().rotation = standardRT;
        _pc.gameObject.SetActive(true);
        nowCharacter = _pc;
        RotationManager.Instance.SetRotationManager(nowCharacter.gameObject);
        sv.SetlCharacter(nowCharacter);
        te.StartCoroutine(te.TypingEffect(nowCharacter.contentText));
    }
}
