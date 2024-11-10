using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class RouteMover : MonoBehaviour
{
    [SerializeField] private Transform[] _routePoints;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private int _indexOfCurrentPoint;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, _routePoints[_indexOfCurrentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _routePoints[_indexOfCurrentPoint].position)
            SwitchToNextPoint();
    }

    public void SwitchToNextPoint()
    {
        float angleOfRotationY = 180f;

        _indexOfCurrentPoint = ++_indexOfCurrentPoint % _routePoints.Length;
        transform.Rotate(new Vector2(0.0f, angleOfRotationY));
    }
}
