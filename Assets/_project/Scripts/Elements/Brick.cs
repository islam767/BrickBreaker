using DG.Tweening;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private AudioManager _audioManager; 
    private Level _level;
    private IncrementalManager   _incrementalManager;

    public Vector2 starthealthRange;
    private int _startHealth;
   private int _health;
    private Color _color;

    public SpriteRenderer spriteR;
    public float colorChangeSpeed ;
    public TextMeshPro healthTMP;

    public BrickType brickType;

    public  void StartBrick(Level level,LevelManagers levelManager)
    {

        _level = level;
        _audioManager = levelManager.gameDirector.audioManager;
        _incrementalManager= levelManager.gameDirector.incrementalManager;
        if (brickType == BrickType.Indestructible)
        {
            if (healthTMP != null)
            {
                healthTMP.gameObject.SetActive(false);
            }
            return;
        }
        _startHealth = Mathf.RoundToInt(Random.Range(starthealthRange.x, starthealthRange.y));
        var bonushealth = levelManager.currentLevelNo / 5;
        _startHealth+= bonushealth;
      
        _health = _startHealth;
        healthTMP.text = _health.ToString();
    
        if (levelManager.currentLevelNo > 20 && levelManager.currentLevelNo < 31)
        {
            _startHealth += 1;
        }
        else if (levelManager.currentLevelNo > 30)

        {
            _startHealth += 2;
        }
    }
    public void GetHit()
    {
        var totalDamage=1+ _incrementalManager.GetDamageUpgradeCount();
        _health-=totalDamage;
        if (brickType == BrickType.Indestructible)
        {
            return;
        }
        PlayVVisualFX();
        if (brickType == BrickType.Tough)
        {
            _level.ToughBrickHit(transform.position);
        }
        if (_health <=0)
        {
            DEstroyBrick();
        }
        else
        {
            healthTMP.text = _health.ToString();
        }
    }

    private void PlayVVisualFX()
    {
        spriteR.transform.DOKill(true);
        
        spriteR.transform.DOScale(1f, .50f).SetLoops(2, LoopType.Yoyo);
    
        spriteR.transform.DOPunchPosition(Vector3.one*.5f,.5f,10);
        healthTMP.DOKill(true);
        healthTMP.color= Color.white;
        healthTMP.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);

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
public enum  BrickType
{
    Basic,
    Indestructible,
    Tough,
}
