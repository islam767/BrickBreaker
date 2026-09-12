using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManagers levelManagers;
    public BreakManagers breakManagers;
    public Player player;
    internal object lose;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
      if (Input.GetKeyDown(KeyCode.E))
        {
            loadNextLEvel();
        }
      if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadPreviousLevel();
        }
    }
    private void loadNextLEvel()
    {
        levelManagers.currentLevelNo = Mathf.Max(levelManagers.currentLevelNo- 1,1);
        RestartLevel(); 
    }

    private void LoadPreviousLevel()
    {
        levelManagers.currentLevelNo += 1;
        RestartLevel();
    }


   public void RestartLevel()
    {
       
        // bolum olsutur
        // dusmanlari olustur
        // oyuncuyu resetle
        levelManagers.RestartLevelManager();
        breakManagers.RestartBreakManager();
        player.RestartPlayer();
    }

    public void Win()
    {
        Invoke(nameof(loadNextLEvel), 1f);
          
    }

    public  void Lose()
    {
        levelManagers.SetBallDirektion(Vector3.zero);
        Invoke(nameof(RestartLevel), 1f);
    }
}
