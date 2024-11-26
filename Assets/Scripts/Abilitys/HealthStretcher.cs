using System;
using System.Collections;
using UnityEngine;

public class HealthStretcher : MonoBehaviour
{
    [SerializeField] private HealthStretcherTrigger _healthStretcherTrigger;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _duration;
    [SerializeField] private float _rechargeTime;
    [SerializeField] private float _damageDelay;
    [SerializeField] private int _damage;

    private bool _isAvailable = true;

    public event Action<float> Activated;

    public float Duration => _duration;

    private void Awake()
    {
        Activated?.Invoke(Duration);
    }

    private void OnEnable()
    {
        _playerInput.PressedAbility += UseAbility;
    }

    private void OnDisable()
    {
        _playerInput.PressedAbility -= UseAbility;
    }

    private void UseAbility()
    {
        if (_isAvailable)
        {
            _isAvailable = false;
            _healthStretcherTrigger.SpriteRenderer.enabled = true;

            StartCoroutine(nameof(StretchingHealth));
        }
    }

    private IEnumerator StretchingHealth()
    {
        var waitForDamage = new WaitForSeconds(_damageDelay);
        var waitForRecharge = new WaitForSeconds(_rechargeTime);

        for (float i = _duration; i >= 0; i--)
        {
            Activated?.Invoke(i);

            if (_healthStretcherTrigger.Enemy != null && _healthStretcherTrigger.Enemy.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);

            yield return waitForDamage;
        }

        _healthStretcherTrigger.SpriteRenderer.enabled = false;

        yield return waitForRecharge;

        Activated?.Invoke(_duration);
        _isAvailable = true;
    }
}
