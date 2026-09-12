
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{
    public GameDirector gameDirector;
    public List<Level> levels;
    public Ball ballPrefab;

    public int currentLevelNo;
   
    private Level _currentLevel;
    private Ball _currentBall;
    public  void RestartLevelManager()
    {
        DeletePreveiosLevel();
        CreateNevLevel();
        DeletePreveiosball();
        CreateNewBall();
    }

    private void CreateNewBall()
    {

       _currentBall = Instantiate(ballPrefab);
        _currentBall.transform.position = new Vector3 (0,-3f,0);
        _currentBall.StartBall(new Vector3 (Random.Range(-1f,1f),1,0));   

    }

    private void DeletePreveiosball()
    {
      if (_currentBall != null)
        {
            Destroy(_currentBall.gameObject);
        }
    }

    private void CreateNevLevel()
    {
        var normalizedLevelNo = (currentLevelNo) % levels.Count;
        _currentLevel = Instantiate(levels[normalizedLevelNo]);
        _currentLevel.transform.position = Vector3.zero;
        _currentLevel.StartLevel(this);

    }

    private void DeletePreveiosLevel()
    {
         if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
    }

    public void LevelCleard()
    {
        _currentBall.SetBalldirektion(Vector3.zero);
        gameDirector.Win();
    }

    public void SetBallDirektion(Vector3 zero)
    {
        _currentBall.SetBalldirektion (Vector3.zero);
    }
}
