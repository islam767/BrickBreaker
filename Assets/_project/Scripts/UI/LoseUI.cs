using DG.Tweening;
using UnityEngine;

public class LoseUI : MonoBehaviour
{
    public UIManager uiManager;
    private CanvasGroup canvasG;
    private void Awake()
    {
        canvasG = GetComponent<CanvasGroup>();
    }
    public void Show(float delay)
    {
        gameObject.SetActive(true);
        canvasG.DOFade(1, 0.1f).SetDelay(delay);
    }
    public void Hide()
    {
        canvasG.DOFade(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
    public void restartButtonPressed()
    {
        uiManager.PlayLevelButtonPressed();
        Hide();
    }
}
