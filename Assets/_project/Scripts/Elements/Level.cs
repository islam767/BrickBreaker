
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level : MonoBehaviour
{
    public Brick brickPrefab;
    private List<Brick> _bricks=new List<Brick>();  
    private FXMAnager _fxManager;
    private LevelManagers _levelManagers;

    public Tile tilePrefeb;
    private List<Tile> _availabelTiles = new List<Tile>();
    public void StartLevel(LevelManagers levelManager)
    {
        _levelManagers = levelManager;
        _fxManager=_levelManagers.gameDirector.fxManager;
        GenerationAvailable();
        var brickCount = 1;
        if (_levelManagers.currentLevelNo+1<11)
        {
            brickCount= _levelManagers.currentLevelNo+1;
        }
        else
        {
            var diffrence = _levelManagers.currentLevelNo+1 - 10;
            brickCount = 10+ diffrence / 2;
        }
        brickCount = Mathf.Min(brickCount, 20);
        //  _bricks = GetComponentsInChildren<Brick>().ToList(); belki bool ile degistire bilirizz
        GenerationBrick(brickCount);
        
    }

    private void GenerationAvailable()
    {
       /* var xstep = 1.5f;
        var ystep = 0.5f;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var newtile = Instantiate(tilePrefeb, transform);
                newtile.transform.localPosition = new Vector3(-1.5f+xstep*j,i*ystep,0);
                _availabelTiles.Add(newtile);
            }
        }
       */
       
        var xstep = 1.5f;
        var ystep = 0.5f;
        var startY = 1.5f; // Bu deðeri artýrarak grubu yukarý, azaltarak aþaðý kaydýrabilirsiniz

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var newtile = Instantiate(tilePrefeb, transform);
                // i * ystep deðerine startY eklendi
                newtile.transform.localPosition = new Vector3(-1.5f + xstep * j, startY + (i * ystep), 0);
                _availabelTiles.Add(newtile);
            }
        }
    }


    private void GenerationBrick(int brickCount)
    {
        var state = Random.state;
        Random.InitState(_levelManagers.currentLevelNo);
        for (int i = 0; i <brickCount; i++)
        {
            var newBricks = Instantiate(brickPrefab, transform);
            var xPosRandom = Random.Range(-1f, 2);

            newBricks.transform.localPosition = selectFromavailabletiles();
            _bricks.Add(newBricks);
            newBricks.StartBrick(this, _levelManagers);
        }
        Random.state = state;
    }
   Vector3 selectFromavailabletiles()
    {
        var selecetedTile = _availabelTiles[Random.Range(0, _availabelTiles.Count)];
        _availabelTiles.Remove(selecetedTile);
        return selecetedTile.transform.position;
    }

    public void BrickDestroy(Brick brick)
    {
        _bricks.Remove(brick);
        _fxManager.PlayBDP(brick.transform.position);
        if (Random.value < 0.5f)
        {
            _levelManagers.gameDirector.coinManager.CreatCoinAtPositon(brick.transform.position);
        }
        _levelManagers.gameDirector.coinManager.CreatCoinAtPositon(brick.transform.position);
        if (_bricks.Count == 0)
        {
            _levelManagers.LevelCleard();
        }
    }
}
