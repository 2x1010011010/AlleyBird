using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    private int _platformCounter;
    private int _coinCounter;

    public event UnityAction OnPlatformCounterChanged;
    public event UnityAction OnCoinCounterChanged;
    public event UnityAction OnBirdDie;

    public int CoinCounter => _coinCounter;
    public int PlatformCounter => _platformCounter;

    private void Start()
    {
        ResetCounters();
    }

    public void AddPlatformCounter()
    {
        _platformCounter+=1;
        OnPlatformCounterChanged?.Invoke();
    }
    public void AddCoinCounter(int value)
    {
        _coinCounter += value;
        OnCoinCounterChanged?.Invoke();
    }
    public void Die()
    {
        OnBirdDie?.Invoke();
    }

    public void ResetCounters()
    {
        _coinCounter = 0;
        _platformCounter = 0;
        OnCoinCounterChanged?.Invoke();
        OnPlatformCounterChanged?.Invoke();
    }
}
