using UnityEngine;

public class Chaser : MonoBehaviour
{
    private float _speed;

    private const int NullVertical = 0;
    private const int Up = 1;
    private const int Down = 2;
    private const int NullHorizontal = 0;
    private const int Left = 1;
    private const int Right = 2;

    private int _verticalMovement = NullVertical;
    private int _horizontalMovement = NullHorizontal;
    private Vector3 _movement;
    private Vector3 _relativeMovement;

    private Transform _chaser;

    private void Awake()
    {
        _chaser = GetComponent<Transform>();
        _speed = Random.Range(1f, 2.5f);
    }

    private void Update()
    {
        _relativeMovement = Vector3.zero;

        if (_verticalMovement == Up)
        {
            _relativeMovement += new Vector3(0, _speed * Time.deltaTime, 0);
        }
        else if(_verticalMovement == Down)
        {
            _relativeMovement += new Vector3(0, -_speed * Time.deltaTime, 0);
        }
        if (_horizontalMovement == Left)
        {
            _relativeMovement += new Vector3(-_speed * Time.deltaTime, 0, 0);
        }
        else if (_horizontalMovement == Right)
        {
            _relativeMovement += new Vector3(_speed * Time.deltaTime, 0, 0);
        }

        _movement = Vector3.ClampMagnitude(_relativeMovement, _speed * Time.deltaTime);
        _chaser.Translate(_movement);
    }
}
