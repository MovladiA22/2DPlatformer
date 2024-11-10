using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] float _speed;
    [SerializeField] PlayerAnimator _animator;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    float _angleOfRotationY = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis(Horizontal);
        Vector2 movement = _rigidbody.velocity;

        movement.x = moveHorizontal * _speed * Time.fixedDeltaTime;
        _rigidbody.velocity = movement;

        if (moveHorizontal > 0)
        {
            _angleOfRotationY = 0f;
            _animator.ActivateRunning();
        }
        else if (moveHorizontal < 0)
        {
            _angleOfRotationY = 180f;
            _animator.ActivateRunning();
        }
        else
        {
            _animator.DeactivateRunning();
        }

        transform.eulerAngles = new Vector2(0.0f, _angleOfRotationY);
    }
}
