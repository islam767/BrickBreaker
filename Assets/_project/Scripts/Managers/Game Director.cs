using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManagers levelManagers;
    public FXMAnager fxManager;
    public CoinManager coinManager;
    public AudioManager audioManager;
    // public BreakManagers breakManagers;
    public IncrementalManager incrementalManager;
    public Player player;
    public object lose;
    public UIManager uiManager;
    public PowerUpManager powerUpManager;


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
        LoadPersistanceData();
        uiManager.GameStarted();
    }

    private void LoadPersistanceData()
    {
        var levelNo = Math.Max(PlayerPrefs.GetInt("levelNo"),1);
        levelManagers.currentLevelNo = levelNo;
        coinManager.coinCount =PlayerPrefs.GetInt("coincount");
        incrementalManager.LoadPersistanceData();
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
        coinManager.StopCoinSpawnC();
        // bolum olsutur
        // dusmanlari olustur
        // oyuncuyu resetle
        levelManagers.RestartLevelManager();
       // breakManagers.RestartBreakManager();
        player.RestartPlayer();
        uiManager.ShowInGameUI(levelManagers.currentLevelNo);
        coinManager.StartCoinSpawnerC();
    }

    public void Win()
    {
        PlayerPrefs.SetInt("levelNo",levelManagers.currentLevelNo+1);
        levelManagers.SetBallsDirektion(Vector3.zero);
        levelManagers.HideBalls();
        uiManager.LevelCompleted();
        coinManager.StopCoinSpawnC();
        coinManager.DEstroyActiveCoins();
        powerUpManager.DEstroyActivePowerUps();

    }

    public void Lose()
    {
        audioManager.PlayFallSound();
        levelManagers.SetBallsDirektion(Vector3.zero);
        levelManagers.HideBalls();
        uiManager.LevelFailed();
        coinManager.StopCoinSpawnC();
        coinManager.DEstroyActiveCoins();
        powerUpManager.DEstroyActivePowerUps();
    }
}
