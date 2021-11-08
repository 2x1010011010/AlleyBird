using UnityEngine;

public class CatSpawner : Pool
{
    [SerializeField] private GameObject[] _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Bird _bird;
    private bool _isSpawned = false;

    private void Start()
    {
        Initialize(_template);
    }

    public void Spawn()
    {

        if (TryGetObject(out GameObject cat) && !_isSpawned)
        {
            _isSpawned = true;
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            cat.transform.position = _spawnPoints[randomIndex].position;
            cat.SetActive(true);
        }


        if (_isSpawned)
        {
            int randomNumber = Random.Range(2, 5);
            if (_bird.PlatformCounter % randomNumber == 0)
            {
                _isSpawned = false; 
            } 
        }
        DisableObjectAbroadCamera();
    }
}
