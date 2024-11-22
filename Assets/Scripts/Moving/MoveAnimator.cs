using UnityEngine;

public class MoveAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _mover;

    private readonly int _isRun = Animator.StringToHash(nameof(_isRun));

    private void OnEnable()
    {
        _mover.Moved += ToggleRun;
    }

    private void OnDisable()
    {
        _mover.Moved -= ToggleRun;
    }

    private void ToggleRun(bool isRun) =>
        _animator.SetBool(_isRun, isRun);
}
