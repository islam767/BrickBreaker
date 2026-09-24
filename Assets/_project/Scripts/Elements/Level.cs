using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    private List<Brick> _bricks;  
    private FXMAnager _fxManager;
    private LevelManagers _levelManagers;
    public void StartLevel(LevelManagers levelManager)
    {
        _levelManagers = levelManager;
        _fxManager=_levelManagers.gameDirector.fxManager;
        _bricks = GetComponentsInChildren<Brick>().ToList();
        foreach (var brick in _bricks)
        {
            brick.StartBrick(this);
        }
    }

    public void BrickDestroy(Brick brick)
    {
        _bricks.Remove(brick);
        _fxManager.PlayBDP(brick.transform.position);
        if (_bricks.Count == 0)
        {
            _levelManagers.LevelCleard();
        }
    }
}
