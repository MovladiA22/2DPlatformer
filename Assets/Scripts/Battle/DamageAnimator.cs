using UnityEngine;

public class DamageAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Damager _damager;

    private readonly int _attack = Animator.StringToHash(nameof(_attack));

    private void OnEnable()
    {
        _damager.Attacked += ActivateAttack;
    }

    private void OnDisable()
    {
        _damager.Attacked -= ActivateAttack;
    }

    private void ActivateAttack() =>
        _animator.SetTrigger(_attack);
}
