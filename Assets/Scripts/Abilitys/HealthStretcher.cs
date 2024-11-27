using System;
using System.Collections;
using UnityEngine;

public class HealthStretcher : MonoBehaviour
{
    [SerializeField] private HealthStretcherTrigger _healthStretcherTrigger;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _rechargeTime;
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;

    private bool _isAvailable = true;
    private YieldInstruction _wait;

    public event Action Activated;

    [field: SerializeField] public float Duration {  get; private set; }

    public float RemainingDuration { get; private set; }

    private void Awake()
    {
        RemainingDuration = Duration;
        _wait = new WaitForSeconds(_delay);
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
        while (RemainingDuration > 0)
        {
            RemainingDuration--;
            Activated?.Invoke();

            if (_healthStretcherTrigger.Enemys.Count > 0)
            {
                GetIDamageable(out int index).TakeDamage(GetHealthForAbsorption(index));
                _playerHealth.Replenish(_damage);
            }

            yield return _wait;
        }

        _healthStretcherTrigger.SpriteRenderer.enabled = false;
        StartCoroutine(nameof(RechargingAbility));
    }

    private IEnumerator RechargingAbility()
    {
        while (RemainingDuration < Duration)
        {
            RemainingDuration += Duration / _rechargeTime;
            Activated?.Invoke();

            yield return _wait;
        }

        _isAvailable = true;
    }

    private IDamageable GetIDamageable(out int indexOfMinDistance)
    {
        float minDistance = 0.0f;
        indexOfMinDistance = 0;

        for (int i = 0; i < _healthStretcherTrigger.Enemys.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, _healthStretcherTrigger.Enemys[i].position);

            if (distance < minDistance)
            {
                minDistance = distance;
                indexOfMinDistance = i;
            }
        }    

        return _healthStretcherTrigger.Enemys[indexOfMinDistance].gameObject.GetComponent<IDamageable>();
    }

    private int GetHealthForAbsorption(int indexOfEnemy)
    {
        if (_healthStretcherTrigger.Enemys[indexOfEnemy].TryGetComponent(out Health health) && health.CurrentValue < _damage)
            return health.CurrentValue;

        return _damage;
    }

}
