using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    private readonly int IsRan = Animator.StringToHash(nameof(IsRan));

    private void OnEnable()
    {
        _playerMovement.Ran += ToggleRunning;
    }

    private void OnDisable()
    {
        _playerMovement.Ran -= ToggleRunning;
    }

    private void ToggleRunning(float direction)
    {
        if (direction == 0)
            _animator.SetBool(IsRan, false);
        else
            _animator.SetBool(IsRan, true);
    }
}
