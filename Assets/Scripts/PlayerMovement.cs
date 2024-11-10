using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private PlayerInput _playerInput;

    public event Action<float> Ran;
    private Rigidbody2D _rigidbody;
    private float _angleOfRotationY = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.MovedHorizontally += Move;
    }

    private void OnDisable()
    {
        _playerInput.MovedHorizontally -= Move;
    }

    private void Move(float moveHorizontal)
    {
        Vector2 movement = _rigidbody.velocity;
        movement.x = moveHorizontal * _speed * Time.fixedDeltaTime;
        _rigidbody.velocity = movement;

        if (moveHorizontal > 0)
            _angleOfRotationY = 0f;
        else if (moveHorizontal < 0)
            _angleOfRotationY = 180f;

        Ran?.Invoke(moveHorizontal);
        transform.eulerAngles = new Vector2(0.0f, _angleOfRotationY);
    }
}
