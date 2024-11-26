using System.Collections;
using UnityEngine;

public class HealthBarRenderer : BarRenderer
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Changed += Render;
    }

    private void OnDisable()
    {
        _health.Changed -= Render;
    }

    protected override IEnumerator RenderingSmooth(float targetValue)
    {
        targetValue = targetValue / _health.MaxValue;

        return base.RenderingSmooth(targetValue);
    }
}
