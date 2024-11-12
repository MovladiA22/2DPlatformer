using System;
using UnityEngine;

public class BanditsZone : MonoBehaviour
{
    public event Action<Transform> Entered;
    public event Action Left;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
            Entered?.Invoke(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
            Left?.Invoke();
    }
}
