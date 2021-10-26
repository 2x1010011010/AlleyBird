using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private int _direction = -1;

    public event UnityAction BirdFly;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if(_rigidbody.velocity.y != 0)
            BirdFly?.Invoke();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_speed * _direction, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed * _direction, 0);
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    public void ChangeDirection()
    {
        _direction *= -1;
        _sprite.flipX = !_sprite.flipX;
    }

    public void ResetVelocity()
    {
        _rigidbody.velocity = new Vector2(0, 0);
    }
}
