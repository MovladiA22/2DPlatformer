using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int IsRan = Animator.StringToHash(nameof(IsRan));

    public void ActivateRunning()
    {
        _animator.SetBool(IsRan, true);
    }

    public void DeactivateRunning()
    {
        _animator.SetBool(IsRan, false);
    }
}
