using UnityEngine;
using TMPro;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _platformCounter;
    [SerializeField] private TMP_Text _totalScore;
    [SerializeField] private TMP_Text _platformCounterRecord;

    [SerializeField] private CanvasGroup _canvasGroup;

    public void Open()
    {
        _canvasGroup.alpha = 1;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
    }

    public void ShowScore(int score, int totalScore)
    {
        _score.text = score.ToString();
        _totalScore.text = totalScore.ToString();
    }

    public void ShowPlatformsCounter(int counter, int record)
    {
        _platformCounter.text = counter.ToString();
        _platformCounterRecord.text = record.ToString();
    }
}
