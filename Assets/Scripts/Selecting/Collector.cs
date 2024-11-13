using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action<Money> PickedUpMoney;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ISelected selected))
        {
            if (collision.gameObject.TryGetComponent(out Money money))
                PickedUpMoney?.Invoke(money);

            if (collision.gameObject.TryGetComponent(out MedKit medKit))
                _health.ReplenishHealth(medKit.Value);

            Destroy(collision.gameObject);
        }
    }
}
