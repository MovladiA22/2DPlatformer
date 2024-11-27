using System;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private IDamageable _damageable = null;

    public event Action<IDamageable> Triggerd;

    public IDamageable Damageable => _damageable;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player) && collision.gameObject.TryGetComponent(out IDamageable damageable))
            Triggerd?.Invoke(damageable);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            _damageable = damageable;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            _damageable = null;
    }
}
