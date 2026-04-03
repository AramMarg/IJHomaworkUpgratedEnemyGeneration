using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Transform[] _wayPoints;

    private int _currentIndex = 0;

    private void Update()
    {
        if (transform.position == _wayPoints[_currentIndex].position)
        {
            _currentIndex = ++_currentIndex % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentIndex].position,
                _speed * Time.deltaTime);
    }

    public void SetWayPoints(Transform[] points)
    {
        _wayPoints = points;
    }
}
