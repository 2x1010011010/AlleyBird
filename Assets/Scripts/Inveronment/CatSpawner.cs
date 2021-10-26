using UnityEngine;

public class CatSpawner : Pool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Bird _bird;
    private bool _isSpawned = false;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        if (_bird.PlatformCounter != 0 && _bird.PlatformCounter % 2 == 0)
        {
            if (TryGetObject(out GameObject cat) && !_isSpawned)
            {
                _isSpawned = true;
                int randomIndex = Random.Range(0, _spawnPoints.Length);
                cat.transform.position = _spawnPoints[randomIndex].position;
                cat.SetActive(true);
            }
        }


        if (_isSpawned)
        {
            int randomNumber = Random.Range(3, 5);
            if (_bird.PlatformCounter % randomNumber == 0)
            {
                _isSpawned = false; 
            } 
        }
        DisableObjectAbroadCamera();
    }
}
