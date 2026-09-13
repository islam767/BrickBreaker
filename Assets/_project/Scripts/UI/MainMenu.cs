using DG.Tweening;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public UIManager uiManager;
   private CanvasGroup canvasG;
   
    private void Awake()
    {
        canvasG = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        canvasG.DOFade(1, 0.5f);
    }
    public void Hide()
    {
        canvasG.DOFade(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
    public void PlayGameButtonPressed()
    {
        uiManager.PlayGameButtonPressed();
        Hide();
    }
   
}
