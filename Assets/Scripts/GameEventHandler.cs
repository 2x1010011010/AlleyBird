using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private BirdMover _mover;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private BirdAnimationSwitcher _animator;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private GameOverScreen _gameoverScreen;
    [SerializeField] private CatSpawner _catSpawner;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private PlatformMover _platformMover;

    private void OnEnable()
    {
        _bird.OnCoinCounterChanged += OnScoreIncrease;
        _bird.OnPlatformCounterChanged += OnPlatformCounterChanged;
        _bird.OnBirdDie += OnBirdDie;
        _startScreen.StartButtonClick += OnStartButtonClick;
        _mover.BirdFly += OnBirdFly;
        _groundChecker.BirdOnGround += OnBirdOnGround;
        _gameoverScreen.RestartButtonClick += OnRestartButtonClick;
        _platformMover.PlatformMoved += OnPlatformMoved;
    }

    private void OnDisable()
    {
        _bird.OnBirdDie -= OnBirdDie;
        _bird.OnCoinCounterChanged -= OnScoreIncrease;
        _bird.OnPlatformCounterChanged -= OnPlatformCounterChanged;
        _startScreen.StartButtonClick -= OnStartButtonClick;
        _mover.BirdFly -= OnBirdFly;
        _groundChecker.BirdOnGround -= OnBirdOnGround;
        _gameoverScreen.RestartButtonClick -= OnRestartButtonClick;
        _platformMover.PlatformMoved -= OnPlatformMoved;
    }

    private void Start()
    {
        _gameScreen.Close();
        _gameoverScreen.Close();
        _startScreen.Open();
        Time.timeScale = 0;
    }
    private void OnBirdFly()
    {
        _animator.PlayAnimation("Flying");
    }
    private void OnBirdOnGround()
    {
        if(Time.timeScale == 1)
            _animator.PlayAnimation("Walk");
    }

    private void OnBirdDie()
    {
        _mover.ResetVelocity();
        _animator.PlayAnimation("Die");
        _gameScreen.Close();
        _gameoverScreen.Open();
        Time.timeScale = 0;
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        _gameScreen.Open();
        OnBirdOnGround();
        Time.timeScale = 1;
    }

    private void OnRestartButtonClick()
    {
        _bird.ResetCounters();
        _gameoverScreen.Close();
        _catSpawner.ResetPool();
        _coinSpawner.ResetPool();
        OnStartButtonClick();
    }

    private void OnScoreIncrease()
    {
        _gameScreen.ShowScore(_bird.CoinCounter);
    }

    private void OnPlatformCounterChanged()
    {
        _gameScreen.ShowPlatformsCounter(_bird.PlatformCounter);
    }

    private void OnPlatformMoved()
    {
        _catSpawner.Spawn();
    }
}
