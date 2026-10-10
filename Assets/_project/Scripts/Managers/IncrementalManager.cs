using System;
using UnityEngine;

public class IncrementalManager : MonoBehaviour
{
    public CoinManager coinManager;
    private int _damageUpgradeCount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            ResetDamageUpgrade();
        }
    }
    public void DamageUpgradeButtonPressed()
    {
        coinManager.SpendCoins(GetDamageUpgradeCost());
        UpgradeDamage();
       
        
    }
    public int GetDamageUpgradeCost()
    {
        return 100 + _damageUpgradeCount * 100;
    }
    private void ResetDamageUpgrade()
    {
        PlayerPrefs.SetInt("DamageUpgrade", 0);
        _damageUpgradeCount = 0;
    }

    public void UpgradeDamage()
    {
        _damageUpgradeCount++;
        PlayerPrefs.SetInt("DamageUpgrade", _damageUpgradeCount);
    }

    public void LoadPersistanceData()
    {
        _damageUpgradeCount=PlayerPrefs.GetInt("DamageUpgrade", 0);
    }
    public int GetDamageUpgradeCount()
    {
        return _damageUpgradeCount;
    }
}
