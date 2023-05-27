using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSensor : MonoBehaviour
{
    public int _errorMargin = 1; 

    private Transform _transform;
    private Vector3 _position;
    public int _x;
    public int _y;
    public int _z;
    public int _r;
    public int _q;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    /*void Update()
    {
        _position = _transform.position;
        _x = Mathf.FloorToInt(_position.x * _errorMargin);
        _y = Mathf.FloorToInt(_position.y * _errorMargin);
        _z = Mathf.FloorToInt(_position.z * _errorMargin);
    }*/
}
