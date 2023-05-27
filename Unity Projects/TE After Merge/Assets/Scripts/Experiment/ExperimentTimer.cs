using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentTimer : MonoBehaviour
{
    [SerializeField]
    private Experiment _experiment;

    private const int _secondsToWait = 2;
    private float _startTime;

    private void Awake()
    {
        enabled = true;
    }

    private void OnEnable()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        if(Time.time - _startTime >= _secondsToWait)
        {
            _experiment.enabled = true;
            enabled = false;
        }
    }

}
