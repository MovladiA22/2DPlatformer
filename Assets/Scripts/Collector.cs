using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Money> PickedUpMoney;
    public event Action<Health> PickedUpHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ISelected selected))
        {
            if (collision.gameObject.TryGetComponent(out Money money))
                PickedUpMoney?.Invoke(money);

            if (collision.gameObject.TryGetComponent(out Health health))
                PickedUpHealth?.Invoke(health);

            Destroy(collision.gameObject);
        }
    }
}
