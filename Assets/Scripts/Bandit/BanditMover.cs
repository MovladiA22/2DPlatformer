using System;
using UnityEngine;

public class BanditMover : MonoBehaviour
{
    [SerializeField] private Transform[] _routePoints;
    [SerializeField] private BanditsZone _banditsZone;
    [SerializeField] private float _speed;

    private Transform _player;
    private int _indexOfCurrentPoint;
    private bool _isCollided = false;
    private bool _isPlayerTrigger = false;

    public event Action<bool> Run;

    private void Update()
    {
        Run?.Invoke(_isCollided == false);

        if (_isCollided == false)
            MoveToTarget();
    }

    private void OnEnable()
    {
        _banditsZone.Entered += GetIsPlayerEntered;
        _banditsZone.Left += GetIsPlayerLeft;
    }

    private void OnDisable()
    {
        _banditsZone.Entered -= GetIsPlayerEntered;
        _banditsZone.Left -= GetIsPlayerLeft;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isCollided = collision.gameObject.TryGetComponent(out IDamageable damageable);
    }

    private void OnCollisionExit2D()
    {
        _isCollided = false;
    }

    private void MoveToTarget()
    {
        Vector2 target = _routePoints[_indexOfCurrentPoint].position;

        if (_isPlayerTrigger && _player != null)
            target = _player.position;
        else if (transform.position == _routePoints[_indexOfCurrentPoint].position)
            SwitchToNextPoint();

        TurnToTarget(target);
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void GetIsPlayerEntered(Transform player)
    {
        _isPlayerTrigger = true;
        _player = player;
    }

    private void GetIsPlayerLeft() =>
        _isPlayerTrigger = false;

    private void SwitchToNextPoint() =>
        _indexOfCurrentPoint = ++_indexOfCurrentPoint % _routePoints.Length;

    private void TurnToTarget(Vector2 target)
    {
        float angleOfRotationY = 0f;

        if (target.x > transform.position.x)
            angleOfRotationY = 180f;
        else if (target.y > transform.position.y)
            angleOfRotationY = 0f;

        transform.rotation = Quaternion.Euler(0.0f, angleOfRotationY, 0.0f);
    }
}
