using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarRenderer : MonoBehaviour
{
    [SerializeField] private Health Health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private void Awake()
    {
        Render();
    }

    private void OnEnable()
    {
        Health.Changed += Render;
    }

    private void OnDisable()
    {
        Health.Changed -= Render;
    }

    private void Render() 
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(RenderingSmooth());
    }

    private IEnumerator RenderingSmooth()
    {
        var wait = new WaitForEndOfFrame();
        float currentHealth = (float)Health.Value / Health.MaxValue;

        while (_slider.value != currentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth, _delay);
            yield return wait;
        }
    }
}
