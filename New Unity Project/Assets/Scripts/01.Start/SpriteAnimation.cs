using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour
{
    [System.Serializable]
    public class SpriteForAnimation
    {
        public string spriteName;
        public int spriteNum;
        public float animTime;
        public Image target;
        public bool isRoot;
        [HideInInspector]public Sprite[] sprites;
    }

    public SpriteForAnimation[] spriteList;
    public Image touchTheScreen;
    public Button FadeButton;

    UIFadeSystem fadeSystem;
    string path;
    bool[] triggerLateStart;

    // Start is called before the first frame update
    void Awake()
    {
        fadeSystem = GetComponent<UIFadeSystem>();
        triggerLateStart = new bool[spriteList.Length];

        for(int i = 0; i < spriteList.Length; i++)
        {
            SpriteForAnimation sp = spriteList[i];
            sp.sprites = new Sprite[sp.spriteNum];

            path = sp.spriteName + "/" + sp.spriteName + "_";

            for (int j = 0; j < sp.spriteNum; j++)
            {
                Texture2D tx = Resources.Load(path + j) as Texture2D;
                sp.sprites[j] = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), new Vector2(0f, 0f));
            }

            StartCoroutine(Animate(sp.sprites, sp.spriteNum, sp.animTime, sp.target, sp.isRoot, i));
            StartCoroutine(LateStartUI());
        }
    }

    IEnumerator Animate(Sprite[] _spriteList, int _spriteNum, float _animTime, Image _target, bool _isRoot, int _index)
    {
        do
        {
            for (int i = 0; i < _spriteNum; i++)
            {
                _target.sprite = _spriteList[i];
                yield return new WaitForSeconds(_animTime / _spriteNum);
            }
            triggerLateStart[_index] = true;
        }
        while (_isRoot);

        yield return null;
    }

    IEnumerator LateStartUI()
    {
        for(int i = 0; i < triggerLateStart.Length; i++)
        {
            while (!triggerLateStart[i])
            {
                yield return new WaitForEndOfFrame();
            }
        }

        FadeButton.gameObject.SetActive(true);
        touchTheScreen.gameObject.SetActive(true);
        fadeSystem.StartFade(0);

        yield return null;
    }
}
