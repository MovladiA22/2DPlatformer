using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerJumper : MonoBehaviour
{
    private const string GroundTag = "Ground";

    [SerializeField] private float _jumpHeight;
    [SerializeField] private PlayerInput _playerInput;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.PressedSpace += Jump;
    }

    private void OnDisable()
    {
        _playerInput.PressedSpace -= Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
            _isGrounded = false;
    }

    private void Jump()
    {
        if (_isGrounded)
            _rigidbody.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
    }
}
