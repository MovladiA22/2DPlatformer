using UnityEngine;

public class BanditAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BanditMover _banditMover;
    [SerializeField] private Damager _damager;

    private readonly int _isRan = Animator.StringToHash(nameof(_isRan));
    private readonly int _attack = Animator.StringToHash(nameof(_attack));

    private void OnEnable()
    {
        _banditMover.Run += ToggleRunning;
        _damager.Attacked += ActivateAttack;
    }

    private void OnDisable()
    {
        _banditMover.Run -= ToggleRunning;
        _damager.Attacked -= ActivateAttack;
    }

    private void ToggleRunning(bool isRan) =>
        _animator.SetBool(_isRan, isRan);

    private void ActivateAttack() =>
        _animator.SetTrigger(_attack);
}
