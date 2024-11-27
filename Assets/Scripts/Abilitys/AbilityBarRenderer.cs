using System.Collections;
using UnityEngine;

public class AbilityBarRenderer : BarRenderer
{
    [SerializeField] private HealthStretcher _healthStretcher;

    private void Awake()
    {
        StartValue = _healthStretcher.RemainingDuration / _healthStretcher.Duration;
    }

    private void OnEnable()
    {
        _healthStretcher.Activated += Render;
    }

    private void OnDisable()
    {
        _healthStretcher.Activated -= Render;
    }

    protected override IEnumerator RenderingSmooth(float targetValue)
    {
        targetValue = _healthStretcher.RemainingDuration / _healthStretcher.Duration;

        return base.RenderingSmooth(targetValue);
    }
}
