using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int _currentValue;
    [field: SerializeField] public int MaxValue { get; private set; }

    public event Action<float> Changed;

    private void Awake()
    {
        Changed?.Invoke((float)_currentValue);
    }

    public void Lost(int amount)
    {
        if (amount < 0)
            amount = 0;

        _currentValue -= amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);

        Changed?.Invoke((float)_currentValue);
    }

    public void Replenish(int amount)
    {
        if (amount < 0)
            amount = 0;

        _currentValue += amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);

        Changed?.Invoke((float)_currentValue);
    }
}
