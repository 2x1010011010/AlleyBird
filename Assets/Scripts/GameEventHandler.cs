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
    [SerializeField] private HowToPlayScreen _howToPlay;

    [Header("Windows")] 
    [SerializeField] private GameObject _startScreenObject;
    [SerializeField] private GameObject _gameScreenObject;
    [SerializeField] private GameObject _howToPlayObject;
    [SerializeField] private GameObject _gameOverObject;

    private int _totalCoins;
    private int _platformsRecord;

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
        _howToPlayObject.SetActive(false);
        _gameScreenObject.SetActive(false);
        _gameOverObject.SetActive(false);
        _startScreenObject.SetActive(true);
        
        if (PlayerPrefs.HasKey("TotalCoins"))
            _totalCoins = PlayerPrefs.GetInt("TotalCoins");
        else
            _totalCoins = 0;

        if (PlayerPrefs.HasKey("PlatformsRecord"))
            _platformsRecord = PlayerPrefs.GetInt("PlatformsRecord");
        else
            _platformsRecord = 0;

        Time.timeScale = 0;
    }
    private void OnBirdFly()
    {
        _animator.Flight(true);
    }
    private void OnBirdOnGround()
    {
        if(Time.timeScale == 1) 
            _animator.Flight(false);
    }

    private void OnBirdDie()
    {
        _mover.ResetVelocity();
        _animator.Dead(true);
        _gameScreenObject.SetActive(false);
        _gameOverObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnStartButtonClick()
    {
        _animator.Dead(false);
        _startScreenObject.SetActive(false);
        _howToPlayObject.SetActive(true);
        _gameScreenObject.SetActive(true);
        OnBirdOnGround();
        Time.timeScale = 1;
    }

    private void OnRestartButtonClick()
    {
        _bird.ResetCounters();
        _gameOverObject.SetActive(false);
        _catSpawner.ResetPool();
        _coinSpawner.ResetPool();
        OnStartButtonClick();
    }

    private void OnScoreIncrease()
    {
        if(_bird.CoinCounter > 0)
            _totalCoins++;
        PlayerPrefs.SetInt("TotalCoins", _totalCoins);
        _gameScreen.ShowScore(_bird.CoinCounter, _totalCoins);
    }

    private void OnPlatformCounterChanged()
    {   
        if (_bird.PlatformCounter > 0)
            _howToPlayObject.SetActive(false);
        
        if (_bird.PlatformCounter > _platformsRecord)
            _platformsRecord = _bird.PlatformCounter;

        PlayerPrefs.SetInt("PlatformsRecord", _platformsRecord);

        _gameScreen.ShowPlatformsCounter(_bird.PlatformCounter, _platformsRecord);
    }

    private void OnPlatformMoved()
    {
        _catSpawner.Spawn();
        _coinSpawner.Spawn();
    }
}