using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffectSystem : MonoBehaviour
{
    [Header("Text UI")]
    public Text target;

    public IEnumerator TypingEffect(string contentText)
    {
        string result = "";
        for(int i = 0; i < contentText.Length; i++)
        {
            result += contentText.Substring(i, 1);
            target.text = result;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
