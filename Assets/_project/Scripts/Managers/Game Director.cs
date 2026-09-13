using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManagers levelManagers;
    public BreakManagers breakManagers;
    public Player player;
    public object lose;
    public UIManager uiManager;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
      if (Input.GetKeyDown(KeyCode.E))
        {
            loadNextLevel();
        }
      if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadPreviousLevel();
        }
    }
    private void Start()
    {
        uiManager.GameStarted(); 
    }
    public void loadNextLevel()
    {
        levelManagers.currentLevelNo += 1; 
        RestartLevel(); 
    }

    private void LoadPreviousLevel()
    {
        levelManagers.currentLevelNo = Mathf.Max(levelManagers.currentLevelNo - 1, 0);
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
        levelManagers.SetBallDirektion(Vector3.zero);
        levelManagers.HideBall();
        uiManager.LevelCompleted();
    }

    public void Lose()
    {
        levelManagers.SetBallDirektion(Vector3.zero);
        Invoke(nameof(RestartLevel), 1f);
    }
}
