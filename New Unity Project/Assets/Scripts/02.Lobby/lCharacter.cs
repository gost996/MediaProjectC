using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lCharacter : MonoBehaviour
{

    [HideInInspector] public List<int> status = new List<int>();
    [HideInInspector] public int maxStat = 0;
    int statLimit;

    [Header("Status")]
    public int STR;
    public int DEX;
    public int INT;
    public int LUK;    

    // Start is called before the first frame update
    void Awake()
    {
        statLimit = SelectManager.Instance.sv.statLimit;

        status.Add(STR);
        status.Add(DEX);
        status.Add(INT);
        status.Add(LUK);

        for(int i = 0; i < status.Count; i++)
        {
            if (status[i] >= statLimit) status[i] = statLimit - 1;
            if (status[i] > maxStat) maxStat = status[i];
        }
    }    
}
