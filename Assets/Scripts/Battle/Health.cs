using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _currentValue;

    public int Value => _currentValue;

    public void Lost(int amount)
    {
        if (amount < 0)
            amount = 0;

        _currentValue -= amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);
    }

    public void Replenish(MedKit medKit)
    {
        int amount = medKit.Value;

        if (amount < 0)
            amount = 0;

        _currentValue += amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);
    }
}
