using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusViewSystem : MonoBehaviour
{
    [Header("Slider")]
    public List<Slider> statSliders = new List<Slider>();

    [Header("Setting")]
    public int statLimit;
    public float lerpSpd;
    bool breakTrigger = false;

    [Header("lCharacter")]
    List<int> status = new List<int>();
    int maxStat;

    public void SetlCharacter(lCharacter _lc)
    {
        ResetSliders();
        status = _lc.status;
        maxStat = _lc.maxStat;
        StartCoroutine(SetStatusSlider());
    }

    void ResetSliders()
    {
        breakTrigger = false;
        foreach (Slider stat in statSliders) stat.value = 0f;
    }

    IEnumerator SetStatusSlider()
    {
        float maxValue = maxStat / statLimit;
        while(breakTrigger == false)
        {
            for(int i = 0; i < statSliders.Count; i++)
            {
                float statValue = (float)status[i] / (float)statLimit;
                statSliders[i].value += Mathf.Lerp(0, statValue, Time.deltaTime * lerpSpd);
                if (statSliders[i].value >= statValue) breakTrigger = true;
            }
            yield return null;
        }
    }
}
