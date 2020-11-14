using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeSystem : MonoBehaviour
{
    public List<Image> UIs = new List<Image>();
    public float fadeTime;

    public void StartFade(int index)
    {
       StartCoroutine(FadeIn(index));
    }

    IEnumerator FadeIn(int index)
    {
        Color c = UIs[index].color;
        while (c.a < 1f)
        {
            c.a += Time.deltaTime / fadeTime;
            UIs[index].color = c;
            if (c.a >= 1f) c.a = 1f;
            yield return null;
            Debug.Log("in " + c.a);
        }
        StartCoroutine(FadeOut(index)); 
    }

    IEnumerator FadeOut(int index)
    {
        Color c = UIs[index].color;
        while (c.a > 0f)
        {
            c.a -= Time.deltaTime / fadeTime;
            UIs[index].color = c;
            if (c.a <= 0f) c.a = 0f;
            yield return null;
            Debug.Log("out " + c.a);
        }
        StartCoroutine(FadeIn(index));
    }
}
