using UnityEngine;

public class Money : MonoBehaviour
{
    private const string Tag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag))
            Destroy(gameObject);
    }
}
