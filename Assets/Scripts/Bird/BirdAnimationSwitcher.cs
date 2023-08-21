using TMPro;
using UnityEngine;

public class BirdAnimationSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int Fly = Animator.StringToHash("IsFlight");
    private static readonly int Die = Animator.StringToHash("IsDead");

    public void Dead(bool value) => 
        _animator.SetBool(Die, value);

    public void Flight(bool value) =>
        _animator.SetBool(Fly, value);
}
