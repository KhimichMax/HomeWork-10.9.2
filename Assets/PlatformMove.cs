using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    private int _currentTarget = 0;
    private float _waypointRadius = 1;
    [SerializeField] private float _speed;
    
    private void MovePlatforms()
    {
        if (Vector3.Distance(_waypoints[_currentTarget].transform.position, transform.position) < _waypointRadius)
        {
            _currentTarget++;
            if (_currentTarget >= _waypoints.Length)
            {
                _currentTarget = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentTarget].transform.position,
            _speed * Time.deltaTime);
    }

    void Update()
    {
        MovePlatforms();
    }
}
