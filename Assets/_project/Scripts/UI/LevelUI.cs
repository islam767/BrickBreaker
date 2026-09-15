using DG.Tweening;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI levelTMP;
    private CanvasGroup canvasG;
    private void Awake()
    {
        canvasG = GetComponent<CanvasGroup>();
    }
    public void Show(int LevelNo)
    {
        gameObject.SetActive(true);
        canvasG.DOFade(1, 0.1f);
        levelTMP.text = "Level " + (LevelNo + 1);
    }
    public void Hide()
    {
        canvasG.DOFade(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
}
