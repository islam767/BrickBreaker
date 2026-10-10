using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class IncreamantaiUi : MonoBehaviour
{
    public IncrementalManager incrementalManager;
    public CoinManager  coinManager;

    public Button upgradeDamageButton;
    public TextMeshProUGUI damageCostTMP;
    public TextMeshProUGUI curLevelTMP;

    private CanvasGroup canvasG;
    private void Awake()
    {
        canvasG = GetComponent<CanvasGroup>();
    }
    public void Show(float delay)
    {
        gameObject.SetActive(true);
        canvasG.DOFade(1, 0.1f).SetDelay(delay);
        RefereshButton();
    }
    public void Hide()
    {
        canvasG.DOFade(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
    public void DamageUpgradeButtonpressed()
    {
        incrementalManager.DamageUpgradeButtonPressed();
        RefereshButton();
    }
    public void RefereshButton()
    {
        var cost = incrementalManager.GetDamageUpgradeCost();
        var coinCount = coinManager.coinCount;
        if (coinCount>=cost)
        {
            upgradeDamageButton.interactable = true;
        }
        else
        {
            upgradeDamageButton.interactable = false;
        }
        damageCostTMP.text = cost.ToString();
        curLevelTMP.text = "Level " + incrementalManager.GetDamageUpgradeCount().ToString();
        //damageCostTMP.text = cost.ToString();
        //curLevelTMP.text = "LEVEL "+incrementalManager.GetDamageUpgradeCount().ToString();
    }
}
