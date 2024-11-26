using UnityEngine;

public class PlayerDamager : Damager
{
    private const string AnimName = "_attack";

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _playerInput.PressedAttack += TryAttack;
    }

    private void OnDisable()
    {
        _playerInput.PressedAttack -= TryAttack;
    }

    protected override void Attack(IDamageable damageable)
    {
        base.Attack(damageable);
    }

    private void TryAttack()
    {
        if (AttackTrigger.Damageable is IDamageable damageable)
            Attack(damageable);
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimName) == false)
            DeclareEventAttaked();
    }
}
