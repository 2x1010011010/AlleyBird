using UnityEngine;


public class HowToPlayScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Close()
    {
        _canvasGroup.alpha = 0;
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
    }
}
