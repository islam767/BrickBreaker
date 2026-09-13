using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public GameDirector gameDirector;
    public MainMenu mainMenu;
    public WinUI winUI;
    public void GameStarted()
    {
       mainMenu.Show();
        winUI.Hide();
    }

  

   public void PlayGameButtonPressed()
    {
        gameDirector.RestartLevel();

    }

    public void LevelCompleted()
    {
        winUI.Show(.5f);
    }

   public void LoadNextLevelButtonPressed()
    {
       gameDirector.loadNextLevel();
    }
}
