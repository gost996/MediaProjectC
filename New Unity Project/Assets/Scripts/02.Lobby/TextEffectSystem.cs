using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffectSystem : MonoBehaviour
{
    [Header("STE Control")]
    public List<Text> target_STE = new List<Text>();
    public float typingTime_STE;

    [Header("DTE Control")]
    public List<Text> target_RTE = new List<Text>();
    public float typingTime_DTE;

    [HideInInspector] public IEnumerator[] runningSTE;

    private void Awake()
    {
        runningSTE = new IEnumerator[target_RTE.Count];
    }

    public IEnumerator SequentialTypingEffect(string contentText, int index)
    {
        string result = "";
        for(int i = 0; i < contentText.Length; i++)
        {
            result += contentText.Substring(i, 1);
            target_STE[index].text = result;
            yield return new WaitForSeconds(typingTime_STE);
        }
    }

    public IEnumerator DotTypingEffect(string contentText, int index)
    {
        int count = 0;
        while (true)
        {
            switch (count)
            {
                case 0:
                    target_RTE[index].text = contentText + ".";
                    count++;
                    break;
                case 1:
                    target_RTE[index].text = contentText + "..";
                    count++;
                    break;
                case 2:
                    target_RTE[index].text = contentText + "...";
                    count = 0;
                    break;
            }
            yield return new WaitForSeconds(typingTime_DTE);
        }
    }
}
