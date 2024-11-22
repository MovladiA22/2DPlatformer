using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarRenderer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private void Awake()
    {
        Render();
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }

    private void OnEnable()
    {
        _health.Changed += Render;
    }

    private void OnDisable()
    {
        _health.Changed -= Render;
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
        float currentHealth = (float)_health.CurrentValue / _health.MaxValue;

        while (_slider.value != currentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth, _delay);

            yield return wait;
        }
    }
}
