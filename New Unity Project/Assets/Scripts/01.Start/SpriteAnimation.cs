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
        public Sprite[] sprites;
    }

    public SpriteForAnimation[] spriteList;
    public Image touchTheScreen;
    public Button FadeButton;

    UIFadeSystem fadeSystem;
    string path;

    // Start is called before the first frame update
    void Awake()
    {
        fadeSystem = GetComponent<UIFadeSystem>();

        foreach(SpriteForAnimation sp in spriteList)
        {
            sp.sprites = new Sprite[sp.spriteNum];

            path = sp.spriteName + "/" + sp.spriteName + "_";
            
            for (int i = 0; i < sp.spriteNum; i++)
            {
                Texture2D tx = Resources.Load(path + i) as Texture2D;
                sp.sprites[i] = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), new Vector2(0f, 0f));
            }

            StartCoroutine(Animate(sp.sprites, sp.spriteNum, sp.animTime, sp.target)); 
        }
    }

    IEnumerator Animate(Sprite[] _spriteList, int _spriteNum, float _animTime, Image _target)
    {
        for(int i = 0; i < _spriteNum; i++)
        {
            _target.sprite = _spriteList[i];
            yield return new WaitForSeconds(_animTime / _spriteNum);
        }
        FadeButton.gameObject.SetActive(true);
        touchTheScreen.gameObject.SetActive(true);
        fadeSystem.StartFade(0);

        yield return null;
    }
}
