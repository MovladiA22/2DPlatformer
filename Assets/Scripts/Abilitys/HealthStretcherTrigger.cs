using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthStretcherTrigger : MonoBehaviour
{
    private List<Transform> _enemys = new List<Transform>();

    public SpriteRenderer SpriteRenderer {  get; private set; }
    public List<Transform> Enemys => _enemys.ToList();

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IEnemy>(out IEnemy enemy))
            _enemys.Add(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IEnemy>(out IEnemy enemy))
            _enemys.Remove(collision.transform);
    }
}
