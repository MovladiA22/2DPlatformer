using System;
using System.Collections;
using UnityEngine;

public class Damager : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    private YieldInstruction _wait;
    private bool _isFinishedAttack = true;

    public event Action Attacked;

    private void Awake()
    {
        _wait = new WaitForSeconds(_attackDelay);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable) && _isFinishedAttack)
            StartCoroutine(nameof(Attack), damageable);
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0)
            amount = 0;

        if (_health.Value - amount <= 0)
            Destroy(gameObject);

        _health.Lost(amount);
    }

    private IEnumerator Attack(IDamageable damageable)
    {
        _isFinishedAttack = false;
        Attacked?.Invoke();
        damageable.TakeDamage(_damage);

        yield return _wait;
        _isFinishedAttack = true;
    }
}
