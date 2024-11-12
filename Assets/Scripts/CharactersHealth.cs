using UnityEngine;

public class CharactersHealth : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public CharactersHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

    public int Value => _health;

    private void OnEnable()
    {
        if (_collector != null)
            _collector.PickedUpHealth += ReplenishHealth;
    }

    private void OnDisable()
    {
        if (_collector != null)
            _collector.PickedUpHealth -= ReplenishHealth;
    }

    public void ReplenishHealth(Health health)
    {
        if (_health + health.Value >= _maxHealth)
            _health = _maxHealth;
        else
            _health += health.Value;
    }

    public void LostHealth(int amount) =>
        _health -= amount;
}
