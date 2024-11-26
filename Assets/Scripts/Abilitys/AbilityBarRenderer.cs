using System.Collections;
using UnityEngine;

public class AbilityBarRenderer : BarRenderer
{
    [SerializeField] private HealthStretcher _healthStretcher;

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
        targetValue = targetValue / _healthStretcher.Duration;

        return base.RenderingSmooth(targetValue);
    }
}
