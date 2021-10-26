using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private List<Platform> _platforms = new List<Platform>();
    [SerializeField] private Vector3 _platformStartPosition;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _upMovement;
    [SerializeField] private float _distanceBehindCamera;

    private const float _distance = 2.5f;

    private void Update()
    {
        for (int i = 0; i < _platforms.Count; i++)
        {
            Vector3 point = _camera.WorldToViewportPoint(_platforms[i].transform.position);
            if (point.y < _distanceBehindCamera)
            {
                _platforms[i].transform.position = new Vector3(_platforms[i].transform.position.x, _platforms[i].transform.position.y + _upMovement, _platforms[i].transform.position.z);
            }
        }
    }

    public void ResetPlatforms()
    {
        _platforms[0].transform.position = _platformStartPosition;
        for(int i = 1; i < _platforms.Count; i++)
            _platforms[i].transform.position = new Vector3(_platforms[0].transform.position.x, _platforms[i-1].transform.position.y + _distance, _platforms[0].transform.position.z);
    }
}
