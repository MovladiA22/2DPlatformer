using System;
using System.Collections;
using UnityEngine;

public class Damager : MonoBehaviour, IDamageable
{
    [SerializeField] protected AttackTrigger AttackTrigger;
    [SerializeField] private Health _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _damageDelay;

    private YieldInstruction _waitForFinishAttack;
    private YieldInstruction _waitForStartAttack;
    private bool _isFinishedAttack = true;

    public event Action Attacked;

    private void Awake()
    {
        _waitForFinishAttack = new WaitForSeconds(_attackDelay);
        _waitForStartAttack = new WaitForSeconds(_damageDelay);
    }

    public void TakeDamage(int amount)
    {
        float destroyTime = 1f;

        if (amount < 0)
            amount = 0;

        if (_health._currentValue - amount <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, destroyTime);
        }

        _health.Lost(amount);
    }

    protected void DeclareEventAttaked() =>
        Attacked?.Invoke();

    protected virtual void Attack(IDamageable damageable)
    {
        if (_isFinishedAttack)
            StartCoroutine(nameof(AttackWithDelay), damageable);
    }

    private IEnumerator AttackWithDelay(IDamageable damageable)
    {
        DeclareEventAttaked();
        _isFinishedAttack = false;

        yield return _waitForStartAttack;

        damageable.TakeDamage(_damage);

        yield return _waitForFinishAttack;
        _isFinishedAttack = true;
    }
}
