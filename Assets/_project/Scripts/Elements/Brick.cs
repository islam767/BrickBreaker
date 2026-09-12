using DG.Tweening;
using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Level _level;
    public int startHealth;
   private int _health;
    private Color _color;

    public SpriteRenderer spriteR;
    public float colorChangeSpeed ;
   
    public  void StartBrick(Level level)
    {
        _level = level;  
        _health = startHealth;
        spriteR.color = new Color(1, 1-_health* colorChangeSpeed, 1 - _health * colorChangeSpeed, 1);
        
    }
    public void GetHit()
    {
        _health--;
        PlayVVisualFX();
        if (_health == 0)
        {
            DEstroyBrick();
        }
    }

    private void PlayVVisualFX()
    {
        //spriteR.transform.DOKill();
        // spriteR.transform.localScale = .2f*Vector3.one; bunlar tuglalarin hizli carpmasini scelini degismesini onluyor ama ise yaramiyor
        // spriteR.transform.localScale = Vector3.zero;
        spriteR.transform.DOScale(.90f, .10f).SetLoops(2, LoopType.Yoyo);
        spriteR.DOColor(new Color(1, 1 - _health * colorChangeSpeed, 1 - _health * colorChangeSpeed, 1), .1f);
        spriteR.transform.DOPunchPosition(Vector3.one*.5f,.5f,10);
    }

    private void DEstroyBrick()
    {
       gameObject.SetActive(false);
        _level.BrickDestroy(this);
    }
    private void OnDestroy()
    {
        spriteR.transform.DOKill();
        spriteR.DOKill();
    }

}
