using DG.Tweening;
using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private AudioManager _audioManager; 
    public Level _level;
    private IncrementalManager   _incrementalManager;

    public int startHealth;
   private int _health;
    private Color _color;

    public SpriteRenderer spriteR;
    public float colorChangeSpeed ;
   
    public  void StartBrick(Level level,LevelManagers levelManager)
    {
        var bonushealth = 0;
        if (levelManager.currentLevelNo > 20 && levelManager.currentLevelNo < 31)
        {
            startHealth += 1;
        }
        else if (levelManager.currentLevelNo > 30)

        {
            startHealth += 2;
        }


            _level = level;
        _audioManager = levelManager.gameDirector.audioManager;
        _incrementalManager= levelManager.gameDirector.incrementalManager;
        startHealth += bonushealth;
        _health = startHealth;
        spriteR.color = new Color(1, 1-_health * colorChangeSpeed, 1 - _health * colorChangeSpeed, 1);
        }
    public void GetHit()
    {
        var totalDamage=1+ _incrementalManager.GetDamageUpgradeCount();
        _health-=totalDamage;
        PlayVVisualFX();
        if (_health <=0)
        {
            DEstroyBrick();
        }
    }

    private void PlayVVisualFX()
    {
        //spriteR.transform.DOKill();
        // spriteR.transform.localScale = .2f*Vector3.one; //bunlar tuglalarin hizli carpmasini scelini degismesini onluyor ama ise yaramiyor
        // spriteR.transform.localScale = Vector3.zero;
        spriteR.transform.DOScale(.90f, .10f).SetLoops(2, LoopType.Yoyo);
        spriteR.DOColor(new Color(1, 1 - _health * colorChangeSpeed, 1 - _health * colorChangeSpeed, 1), .1f);
        spriteR.transform.DOPunchPosition(Vector3.one*.5f,.5f,10);
    }

    private void DEstroyBrick()
    {
       gameObject.SetActive(false);
        _level.BrickDestroy(this);
        _audioManager.PlayExploadSound();
    }
    private void OnDestroy()
    {
        spriteR.transform.DOKill();
        spriteR.DOKill();
    }

}
