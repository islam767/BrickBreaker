
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Brick brickPrefab;
    private List<Brick> _bricks=new List<Brick>();  
    private FXMAnager _fxManager;
    private LevelManagers _levelManagers;
    public void StartLevel(LevelManagers levelManager)
    {
        _levelManagers = levelManager;
        _fxManager=_levelManagers.gameDirector.fxManager;
        //  _bricks = GetComponentsInChildren<Brick>().ToList(); belki bool ile degistire bilirizz
        GenerationBrick();
    }

    private void GenerationBrick()
    {
        var newBricks = Instantiate(brickPrefab,transform);
        var xPosRandom=Random.Range(-1f,2);
        newBricks.transform.localPosition = new Vector3 (xPosRandom*1.5f,0,0);
        _bricks.Add(newBricks);
        newBricks.StartBrick(this,_levelManagers);
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
