using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;
    [SerializeField] private PlayerInput _playerInput;

    private Rigidbody2D _rigidbody;
    private int _numberOfGround = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Jumped += Jump;
    }

    private void OnDisable()
    {
        _playerInput.Jumped -= Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            _numberOfGround++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            _numberOfGround--;
    }

    private void Jump()
    {
        if (_numberOfGround > 0)
            _rigidbody.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
    }
}
