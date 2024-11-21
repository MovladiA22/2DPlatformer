using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _currentValue;

    public event Action Changed;

    public int MaxValue => _maxValue;
    public int Value => _currentValue;

    public void Lost(int amount)
    {
        if (amount < 0)
            amount = 0;

        _currentValue -= amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);

        Changed?.Invoke();
    }

    public void Replenish(int amount)
    {
        if (amount < 0)
            amount = 0;

        _currentValue += amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);

        Changed?.Invoke();
    }
}
