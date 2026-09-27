using DG.Tweening;
using UnityEngine.UI;
using TMPro;    
using UnityEngine;



public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinTMP;
    public Image coinImage;

    private CanvasGroup canvasG;
    private float coinTextYPos;
    private void Awake()
    {
        canvasG = GetComponent<CanvasGroup>();
        coinTextYPos = coinTMP.transform.localPosition.y;
    }
    public void Show()
    {
        gameObject.SetActive(true);
        canvasG.DOFade(1, 0.1f);    
    }

    public void updateCoinCount(int count)
    {
        coinTMP.text = count.ToString();
        coinTMP.transform.DOKill();
        coinTMP.transform.localPosition = new Vector3(coinTMP.transform.localPosition.x, coinTextYPos,0);
        coinTMP.transform.DOLocalMoveY(coinTMP.transform.localPosition.y+10,.10f).SetLoops(2,LoopType.Yoyo);
        coinImage.transform.DOKill();
        coinImage.transform.localScale = Vector3.one;
        coinImage.transform.DOScale(1.2f,.10f).SetLoops(2,LoopType.Yoyo); 
    }
    public void Hide()
    {
        canvasG.DOFade(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
}
