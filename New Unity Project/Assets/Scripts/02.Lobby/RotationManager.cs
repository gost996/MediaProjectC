using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    [Header("Rotation Pivot")]
    public RectTransform pivot;
    private GameObject pc;
    private Transform pcTransform;
    private Vector3 centerRotation;
    private float prevCenter;
    private static RotationManager _instance;
    public static RotationManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(RotationManager)) as RotationManager;
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
    }

    public void SetRotationManager(GameObject _pc)
    {
        pc = _pc;
        pcTransform = pc.GetComponent<Transform>();
        prevCenter = pivot.anchoredPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) prevCenter = Input.mousePosition.x;
        if (Input.GetMouseButton(0))
        {
            float move_x = Input.mousePosition.x;
            float rot = (prevCenter - move_x)/2;
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = new Vector3(0, rot, 0);
            pcTransform.rotation *= rotation;
            prevCenter = move_x;
        }
    }
}   
