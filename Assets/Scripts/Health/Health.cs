using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Changed;

    [field: SerializeField] public int CurrentValue { get; private set; }
    [field: SerializeField] public int MaxValue { get; private set; }

    public void Lost(int amount)
    {
        if (amount < 0)
            amount = 0;

        CurrentValue -= amount;
        CurrentValue = Mathf.Clamp(CurrentValue, 0, MaxValue);

        Changed?.Invoke();
    }

    public void Replenish(int amount)
    {
        if (amount < 0)
            amount = 0;

        CurrentValue += amount;
        CurrentValue = Mathf.Clamp(CurrentValue, 0, MaxValue);

        Changed?.Invoke();
    }
}
