using UnityEngine;

public class BanditAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BanditMover _mover;

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
