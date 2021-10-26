using UnityEngine;

public class BirdAnimationSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        PlayAnimation("Idle");
    }
    public void PlayAnimation(string animationName)
    {
        
        _animator.StopPlayback();
        _animator.Play(animationName);
    }
}
