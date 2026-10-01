using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public FXMAnager fxmanager;
    public CoinUI coinUI;
    public int coinCount;
    public Coin coinPrefeb;
    private Coroutine coinSpawnCoroutine;
    public void StartCoinSpawnerC()
    {
       coinSpawnCoroutine= StartCoroutine(coinSpawnC());
    }
    IEnumerator coinSpawnC()
    {   
        while (true)
        {
            var spawnTime = UnityEngine.Random.Range(3f, 6f);
            var spawnPos = new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range (0,4.5f),0);
            yield return new WaitForSeconds(spawnTime);
            CreatCoinAtPositon(spawnPos);
           
        }
    }
    public void StopCoinSpawnC()
    {
        if (coinSpawnCoroutine != null)
        {
            StopCoroutine(coinSpawnCoroutine);
           /// coinSpawnCoroutine = null;
        }
    }
    public void CreatCoinAtPositon(Vector3 pos)
    {
        var newCoin = Instantiate(coinPrefeb);
        newCoin.transform.position = pos;
        newCoin.transform.localScale = Vector3.zero;
        newCoin.transform.DOScale(1f,.2f).SetEase(Ease.OutBack);
    }

    public void CoinCollected(Vector3 pos)
    {
      coinCount++;
      coinUI.updateCoinCount(coinCount);
      PlayerPrefs.SetInt("coincount",coinCount);
        fxmanager.CoinGoldPS(pos);
    }























































    //public static CoinManager Instance;

    //[Tooltip("Current total coins")]
    //public int coinCount = 0;

    //[Tooltip("Amount added per collected coin when no amount is provided")]
    //public int defaultCoinValue = 1;

    //[Tooltip("Optional UI Text to show coin total")]
    //public Text coinText;

    //[Tooltip("If true, coins are saved between sessions using PlayerPrefs")]
    //public bool persistWithPlayerPrefs = true;

    //const string PlayerPrefsKey = "TotalCoins";

    //void Awake()
    //{
    //    // Simple singleton (optional, remove if you prefer multiple managers)
    //    if (Instance == null) Instance = this;
    //    else if (Instance != this) Destroy(gameObject);

    //    if (persistWithPlayerPrefs)
    //        coinCount = PlayerPrefs.GetInt(PlayerPrefsKey, coinCount);

    //    UpdateUI();
    //}

    ///// <summary>
    ///// Call this when the player collects a coin.
    ///// If amount is not provided, uses defaultCoinValue.
    ///// </summary>
    //public void CollectCoin(int amount = -1)
    //{
    //    if (amount <= 0) amount = defaultCoinValue;

    //    coinCount += amount;
    //    UpdateUI();

    //    if (persistWithPlayerPrefs)
    //        PlayerPrefs.SetInt(PlayerPrefsKey, coinCount);
    //}

    //void UpdateUI()
    //{
    //    if (coinText != null)
    //        coinText.text = coinCount.ToString();
    //}

    ///// <summary>
    ///// Optional helper to reset saved coins (useful for debugging).
    ///// </summary>
    //public void ResetCoins()
    //{
    //    coinCount = 0;
    //    if (persistWithPlayerPrefs)
    //    {
    //        PlayerPrefs.SetInt(PlayerPrefsKey, coinCount);
    //        PlayerPrefs.Save();
    //    }
    //    UpdateUI();
    //}
}
