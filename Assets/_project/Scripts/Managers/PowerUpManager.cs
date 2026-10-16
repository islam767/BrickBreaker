using System.Collections.Generic;
using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public FXMAnager    fxMAnager;
    public LevelManagers levelManagers;
    public PowerUp powerUps;
    private List<PowerUp> activePowerUps = new List<PowerUp>();

    public void SpawnPowerUP(Vector3 position)
    {
     var newPowerUp = Instantiate(powerUps);
        newPowerUp.transform.position = position;
        activePowerUps.Add(newPowerUp);
    }

    public void PowerUpCollected(PowerUp powerUp)
    {
        levelManagers.PowerUpCollected(powerUp.transform.position);
        fxMAnager.CoinGoldPS(powerUp.transform.position);
        activePowerUps.Remove(powerUp);
    }
    public void DEstroyActivePowerUps()
    {
        foreach (var powerUp in activePowerUps)
        {
            Destroy(powerUp.gameObject);
        }
        activePowerUps.Clear();
    }
    public void PowerUpDestroyed(PowerUp powerUp)
    {
        activePowerUps.Remove(powerUp);
    }
}
