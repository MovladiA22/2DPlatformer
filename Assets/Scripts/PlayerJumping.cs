using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void OnCollisionEnter2D()
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D()
    {
        _isGrounded = false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
        }
    }
}
