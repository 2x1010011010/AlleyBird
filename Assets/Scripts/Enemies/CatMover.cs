using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CatMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private int _direction = 1;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_speed * _direction, _rigidbody.velocity.y);
    }

    public void ChangeDirection()
    {
        _direction *= -1;
        _sprite.flipX = !_sprite.flipX;
    }

}
