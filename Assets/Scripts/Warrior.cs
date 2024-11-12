using System;
using System.Collections;
using UnityEngine;

public class Warrior : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    private bool _isFinishedAttack = true;

    public event Action Attacked;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable) && _isFinishedAttack)
            StartCoroutine(nameof(Attack), damageable);
    }

    public void TakeDamage(int amount)
    {
        if (_health - amount <= 0)
            Destroy(gameObject);

        _health -= amount;
    }

    public void ReplenishHealth(int amount)
    {
        if (_health + amount >= _maxHealth)
            _health = _maxHealth;
        else
            _health += amount;
    }

    private IEnumerator Attack(IDamageable damageable)
    {
        _isFinishedAttack = false;
        Attacked?.Invoke();
        damageable.TakeDamage(_damage);

        yield return new WaitForSeconds(_attackDelay);
        _isFinishedAttack = true;
    }
}
