using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed = 5f;

    private Transform _player;
    private Vector3 _movement;
    private Vector3 _relativeMovement;

    private void Awake()
    {
        _player = GetComponent<Transform>();
    }

    private void Update()
    {
        _relativeMovement = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            _relativeMovement += new Vector3(0, _speed * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            _relativeMovement += new Vector3(0, -_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _relativeMovement += new Vector3(-_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _relativeMovement += new Vector3(_speed * Time.deltaTime, 0, 0);
        }

        _movement = Vector3.ClampMagnitude(_relativeMovement, _speed * Time.deltaTime);
        _player.Translate(_movement);
    }
}
