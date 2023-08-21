using UnityEngine;

[RequireComponent(typeof(Bird), typeof(BirdMover))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] Pool _coinPool;
    private Bird _bird;
    private BirdMover _mover;

    private void Start()
    {
        _bird = GetComponent<Bird>();
        _mover = GetComponent<BirdMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _bird.AddCoinCounter(coin.CoinPrice);
            _coinPool.DeactivateItem(coin.gameObject);
            return;
        }
        
        if (collision.TryGetComponent(out Platform platform))
        {
            return;
        }
        
        if (collision.TryGetComponent(out PlatformCounterTrigger platformCounter))
        {
            _bird.AddPlatformCounter();
            return;
        }
        
        if (collision.TryGetComponent(out Wall wall))
        {
            _mover.ChangeDirection();
        }
        else
        {
            _bird.Die();
        }
    }

}
