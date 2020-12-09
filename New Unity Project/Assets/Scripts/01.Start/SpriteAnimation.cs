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
    }

    public SpriteForAnimation[] spriteList;
    public Image touchTheScreen;

    UIFadeSystem fadeSystem;
    string path;

    // Start is called before the first frame update
    void Awake()
    {
        fadeSystem = GetComponent<UIFadeSystem>();

        foreach(SpriteForAnimation sp in spriteList)
        {
            path = "AnimationSprite/" + sp.spriteName + "/" + sp.spriteName + "_";
            StartCoroutine(Animate(path, sp.spriteNum, sp.animTime, sp.target)); 
        }
    }

    IEnumerator Animate(string _path, int _spriteNum, float _animTime, Image _target)
    {
        for(int i = 0; i < _spriteNum; i++)
        {
            Texture2D tx = Resources.Load(_path + i) as Texture2D;
            Sprite s = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), new Vector2(0f, 0f));
            _target.sprite = s;
            Debug.Log(i);
            yield return new WaitForSeconds(_animTime / _spriteNum);
        }
        touchTheScreen.gameObject.SetActive(true);
        fadeSystem.StartFade(0);

        yield return null;
    }
}
