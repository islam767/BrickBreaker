using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public FXMAnager    fxMAnager;
    public LevelManagers levelManagers;
    public PowerUp powerUps;
    
    public void SpawnPowerUP(Vector3 position)
    {
     var newPowerUp = Instantiate(powerUps);
        newPowerUp.transform.position = position;
    }

    public void PowerUpCollected(Vector3 position)
    {
        levelManagers.PowerUpCollected();
        fxMAnager.CoinGoldPS(position);
    }
}
