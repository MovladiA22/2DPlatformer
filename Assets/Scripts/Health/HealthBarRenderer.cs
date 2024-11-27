using System.Collections;
using UnityEngine;

public class HealthBarRenderer : BarRenderer
{
    [SerializeField] private Health _health;

    private void Awake()
    {
        StartValue = (float)_health.CurrentValue / _health.MaxValue;
    }

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
        targetValue = (float)_health.CurrentValue / _health.MaxValue;

        return base.RenderingSmooth(targetValue);
    }
}
