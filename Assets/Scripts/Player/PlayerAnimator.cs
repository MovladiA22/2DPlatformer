using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Damager _damager;

    private readonly int _isRan = Animator.StringToHash(nameof(_isRan));
    private readonly int _attack = Animator.StringToHash(nameof(_attack));

    private void OnEnable()
    {
        _playerMover.Run += ToggleRunning;
        _damager.Attacked += ActivateAttack;
    }

    private void OnDisable()
    {
        _playerMover.Run -= ToggleRunning;
        _damager.Attacked -= ActivateAttack;
    }

    private void ToggleRunning(bool isRan) =>
        _animator.SetBool(_isRan, isRan);

    private void ActivateAttack() =>
        _animator.SetTrigger(_attack);
}
