using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private float _direction = 0f;
    private bool _pressedSpace = false;

    public event Action<float> MovedHorizontally;
    public event Action PressedSpace;

    private void FixedUpdate()
    {
        MovedHorizontally?.Invoke(_direction);

        if (_pressedSpace)
        {
            PressedSpace?.Invoke();
            _pressedSpace = false;
        }
    }

    private void Update()
    {
        _direction = Input.GetAxis(Horizontal);
        _pressedSpace |= Input.GetKeyDown(KeyCode.Space);
    }
}
