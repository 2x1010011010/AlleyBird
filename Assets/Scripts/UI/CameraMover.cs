using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Bird _target;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _speed;

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, _target.transform.position.y + _offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
