
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{
    public GameDirector gameDirector;
    public List<Level> levels;
    public Ball ballPrefab;

    public int currentLevelNo;
   
    private Level _currentLevel;
   // private Ball _currentBall;
    private List<Ball> _activeballs = new List<Ball>();
    public  void RestartLevelManager()
    {
        DeletePreveiosLevel();
        CreateNevLevel();
        DeletePreveiosballs();
        CreateNewBall(new Vector3 (0,-3,0));
    }

    private void CreateNewBall(Vector3 pos)
    {
        var newBal = Instantiate(ballPrefab);
        newBal.transform.position = pos;
        newBal.StartBall(this,new Vector3 (Random.Range(-1f,1f),1,0));
        _activeballs.Add(newBal);
    }

    private void DeletePreveiosballs()
    {
     foreach (var b in _activeballs)
        {
            Destroy(b.gameObject);
        }
        _activeballs.Clear();
    }

    private void CreateNevLevel()
    {
        var normalizedLevelNo = (currentLevelNo) % levels.Count;
        _currentLevel = Instantiate(levels[normalizedLevelNo]);
        _currentLevel.transform.position = Vector3.zero;
        _currentLevel.StartLevel(this);

    }

    public void DeletePreveiosLevel()
    {
         if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
    }

    public void LevelCleard()
    {
        foreach (var b in _activeballs)
        {
           b.SetBalldirektion(Vector3.zero);
        }
        gameDirector.Win();
    }

    public void SetBallsDirektion(Vector3 zerp)
    {
         foreach (var b in _activeballs)
        {
           b.SetBalldirektion(Vector3.zero);
        }
     
    }

    public  void HideBalls()
    {
        foreach (var b in _activeballs)
        {
        b.transform.DOScale(0, .2f).SetEase(Ease.InBack).OnComplete(()=>Destroy(b.gameObject));
        }
       _activeballs.Clear();
    }

    public void PowerUpCollected(Vector3 pos)
    {
        CreateNewBall(pos);
    }

    public void BallDestroyed(Ball ball)
    {
        _activeballs.Remove(ball);
        if (_activeballs.Count <= 0)
        {
            gameDirector.Lose();
        }
    }
}
