using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public int Value => _health;

    public void LostHealth(int amount)
    {
        if (amount < 0)
            amount = 0;

        _health -= amount;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }

    public void ReplenishHealth(int health)
    {
        if (health < 0)
            health = 0;

        _health += health;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }
}
