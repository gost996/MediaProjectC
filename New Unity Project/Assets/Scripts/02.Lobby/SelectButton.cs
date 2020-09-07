using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public void SetCharacter(int i)
    {
        SelectManager.Instance.SetCharacter(i);
    }
}
