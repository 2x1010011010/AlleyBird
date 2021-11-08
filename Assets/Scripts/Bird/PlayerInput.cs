using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundCheck;
    private BirdMover _birdMover;
    private bool _canDoubleJump;


    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    private void Update()
    {
        if (Time.timeScale == 1 && Input.GetMouseButtonDown(0)) 
        {
            if (_groundCheck.IsGrounded)
            {
                _birdMover.Jump();
                _canDoubleJump = true;
            }
            else if (_canDoubleJump)
            {
                _birdMover.Jump();
                _canDoubleJump = false;
            }
        }
    }
}
