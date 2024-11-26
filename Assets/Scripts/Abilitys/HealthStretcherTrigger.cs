using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthStretcherTrigger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private GameObject _enemy = null;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public GameObject Enemy => _enemy;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IEnemy enemy))
            _enemy = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IEnemy enemy))
            _enemy = null;
    }
}
