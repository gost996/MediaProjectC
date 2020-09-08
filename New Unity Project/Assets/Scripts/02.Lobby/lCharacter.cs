using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lCharacter : MonoBehaviour
{
    [HideInInspector] public int maxStat = 0;
    int statLimit;

    [Header("Status")]
    public List<int> status = new List<int>();

    [Header("Content Text")]
    [TextArea]
    public string contentText = "";

    // Start is called before the first frame update
    void Awake()
    {
        statLimit = SystemManager.Instance.svSystem.statLimit;

        for(int i = 0; i < status.Count; i++)
        {
            if (status[i] >= statLimit) status[i] = statLimit - 1;
            if (status[i] > maxStat) maxStat = status[i];
        }
    }    
}
