using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarRenderer : MonoBehaviour
{
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

    protected void Render(float currentValue = 0.0f)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(RenderingSmooth(currentValue));
    }

    protected virtual IEnumerator RenderingSmooth(float targetValue)
    {
        var wait = new WaitForEndOfFrame();

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _delay);

            yield return wait;
        }
    }
}
