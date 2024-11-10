using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            _wallet.AddMoney(money.Value);
            Destroy(collision.gameObject);
        }
    }
}
