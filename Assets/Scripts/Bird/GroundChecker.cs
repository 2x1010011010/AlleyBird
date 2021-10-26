using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _layer;
    private bool _isGrounded;
    private Rigidbody2D _rigidBody;
    private CapsuleCollider2D _capsuleCollider2D;

    public bool IsGrounded => _isGrounded;

    public event UnityAction BirdOnGround;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(_capsuleCollider2D.bounds.center, Vector2.down, _capsuleCollider2D.bounds.extents.y + _rayDistance, _layer);

        if (raycastHit.collider != null && _rigidBody.velocity.y == 0)
        {
            _isGrounded = true;
            BirdOnGround?.Invoke();
        }
        else
        {
            _isGrounded = false;
        }

    }
}
