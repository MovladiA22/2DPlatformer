using UnityEngine;

public class MoveAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _mover;

    private readonly int _isRan = Animator.StringToHash(nameof(_isRan));

    private void OnEnable()
    {
        _mover.Moved += ToggleRunning;
    }

    private void OnDisable()
    {
        _mover.Moved -= ToggleRunning;
    }

    private void ToggleRunning(bool isRan) =>
        _animator.SetBool(_isRan, isRan);
}
