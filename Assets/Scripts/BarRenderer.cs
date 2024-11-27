using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _delay;

    protected float StartValue = 0.0f;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider.value = StartValue;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }

    protected void Render()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(RenderingSmooth(StartValue));
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
