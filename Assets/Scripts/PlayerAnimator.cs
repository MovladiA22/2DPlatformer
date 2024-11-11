using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    private readonly int IsRan = Animator.StringToHash(nameof(IsRan));

    private void OnEnable()
    {
        _playerMovement.Run += ToggleRunning;
    }

    private void OnDisable()
    {
        _playerMovement.Run -= ToggleRunning;
    }

    private void ToggleRunning(float direction) =>
        _animator.SetBool(IsRan, direction != 0);
}
