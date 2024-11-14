using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _mover;

    private readonly int _isRan = Animator.StringToHash(nameof(_isRan));

    private void OnEnable()
    {
        _mover.Run += ToggleRunning;
    }

    private void OnDisable()
    {
        _mover.Run -= ToggleRunning;
    }

    private void ToggleRunning(bool isRan) =>
        _animator.SetBool(_isRan, isRan);
}
