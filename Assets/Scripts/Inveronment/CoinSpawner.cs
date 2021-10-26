using UnityEngine;

public class CoinSpawner : Pool
{
    [SerializeField] private GameObject[] _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _nextSpawnDelta;
    [SerializeField] private Vector3 _lastSpawn;
    

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        if (_spawnPoints[0].position.y - _lastSpawn.y > _nextSpawnDelta)
        {
            if (TryGetObject(out GameObject coin))
            {
                int randomIndex = Random.Range(0, _spawnPoints.Length);
                coin.transform.position = _spawnPoints[randomIndex].position;
                _lastSpawn = _spawnPoints[randomIndex].position;
                coin.SetActive(true);
            }
        }
        DisableObjectAbroadCamera();
    }
}
