using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private float _direction = 0f;
    private bool _isPressedJumpKey = false;
    private KeyCode _jumpKey = KeyCode.Space;

    public event Action<float> MovedHorizontally;
    public event Action Jumped;

    private void FixedUpdate()
    {
        MovedHorizontally?.Invoke(_direction);

        if (_isPressedJumpKey)
        {
            Jumped?.Invoke();
            _isPressedJumpKey = false;
        }
    }

    private void Update()
    {
        _direction = Input.GetAxis(Horizontal);
        _isPressedJumpKey |= Input.GetKeyDown(_jumpKey);
    }
}
