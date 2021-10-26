using UnityEngine;
using TMPro;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _platformCounter;
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Open()
    {
        _canvasGroup.alpha = 1;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
    }

    public void ShowScore(int score)
    {
        _score.text = score.ToString();
    }

    public void ShowPlatformsCounter(int counter)
    {
        _platformCounter.text = counter.ToString();
    }
}
