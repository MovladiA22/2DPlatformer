using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Warrior _warrior;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PickUpMoney(collision);
        PickUpHealth(collision);
    }

    private void PickUpMoney(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            _wallet.AddMoney(money.Value);
            Destroy(collision.gameObject);
        }
    }

    private void PickUpHealth(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            _warrior.ReplenishHealth(health.Value);
            Destroy(collision.gameObject);
        }
    }
}
