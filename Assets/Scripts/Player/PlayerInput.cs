using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private float _direction = 0f;
    private bool _isPressedJumpKey = false;
    private KeyCode _jumpKey = KeyCode.Space;
    private KeyCode _attackKey = KeyCode.F;
    private KeyCode _abilityKey = KeyCode.R;

    public event Action<float> MovedHorizontally;
    public event Action PressedJump;
    public event Action PressedAttack;
    public event Action PressedAbility;

    private void FixedUpdate()
    {
        MovedHorizontally?.Invoke(_direction);

        if (_isPressedJumpKey)
        {
            PressedJump?.Invoke();
            _isPressedJumpKey = false;
        }
    }

    private void Update()
    {
        _direction = Input.GetAxis(Horizontal);
        _isPressedJumpKey |= Input.GetKeyDown(_jumpKey);

        if(Input.GetKeyDown(_attackKey))
            PressedAttack?.Invoke();

        if(Input.GetKeyDown(_abilityKey))
            PressedAbility?.Invoke();
    }
}
