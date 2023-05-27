using UnityEngine;

public class ChaserImperative : MonoBehaviour
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

    private Transform _player; // Sensor 1
    private Transform _chaser; // Sensor 2

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _chaser = GetComponent<Transform>();

        _speed = Random.Range(1f, 2.5f);
    }

    private void Update()
    {
        _relativeMovement = Vector3.zero;

        // Brain
        if(_chaser.position.y < _player.position.y)
        {
            _verticalMovement = Up;
        }
        else if (_chaser.position.y > _player.position.y)
        {
            _verticalMovement = Down;
        }
        else
        {
            _verticalMovement = NullVertical;
        }
        if(_chaser.position.x < _player.position.x)
        {
            _horizontalMovement = Right;
        }
        else if(_chaser.position.x > _player.position.x)
        {
            _horizontalMovement = Left;
        }
        else
        {
            _horizontalMovement = NullHorizontal;
        }

        if (_verticalMovement == Up)
        {
            if(_player.position.y - _chaser.position.y < _speed * Time.deltaTime)
            {
                _relativeMovement += new Vector3(0, _player.position.y - _chaser.position.y, 0);
            }
            else
            {
                _relativeMovement += new Vector3(0, _speed * Time.deltaTime, 0);
            }
        }
        else if (_verticalMovement == Down)
        {
            if (_player.position.y - _chaser.position.y > -_speed * Time.deltaTime)
            {
                _relativeMovement += new Vector3(0, _player.position.y - _chaser.position.y, 0);
            }
            else
            {
                _relativeMovement += new Vector3(0, -_speed * Time.deltaTime, 0);
            }
        }
        if (_horizontalMovement == Left)
        {
            if (_player.position.x - _chaser.position.x > -_speed * Time.deltaTime)
            {
                _relativeMovement += new Vector3(_player.position.x - _chaser.position.x, 0, 0);
            }
            else
            {
                _relativeMovement += new Vector3(-_speed * Time.deltaTime, 0, 0);
            }
        }
        else if (_horizontalMovement == Right)
        {
            if (_player.position.x - _chaser.position.x < _speed * Time.deltaTime)
            {
                _relativeMovement += new Vector3(_player.position.x - _chaser.position.x, 0, 0);
            }
            else
            {
                _relativeMovement += new Vector3(_speed * Time.deltaTime, 0, 0);
            }
        }

        _movement = Vector3.ClampMagnitude(_relativeMovement, _speed * Time.deltaTime);
        _chaser.Translate(_movement);
    }
}
