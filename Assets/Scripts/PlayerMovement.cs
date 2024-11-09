using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string RunAnim = "IsRan";

    [SerializeField] float _speed;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
            _spriteRenderer.flipX = false;
            _animator.SetBool(RunAnim, true);
        }
        else if (moveHorizontal < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool(RunAnim, true);
        }
        else
        {
            _animator.SetBool(RunAnim, false);
        }
    }
}
