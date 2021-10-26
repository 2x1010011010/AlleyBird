using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinPrice;

    public int CoinPrice => _coinPrice;

}
