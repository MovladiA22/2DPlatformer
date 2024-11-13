using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public int Value => _health;

    public void LostHealth(int amount) =>
        _health -= amount;

    public void ReplenishHealth(int health)
    {
        if (health < 0)
            health = 0;

        if (_health + health >= _maxHealth)
            _health = _maxHealth;
        else
            _health += health;
    }
}
