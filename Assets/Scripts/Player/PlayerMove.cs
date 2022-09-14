using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _spead;

    private Vector3 _playerPosition;

    private void Start()
    {
        _playerPosition = transform.position;
    }

    private void Update()
    {
        _playerPosition.x += Input.GetAxis("Horizontal") * _spead * Time.deltaTime;

        transform.position = _playerPosition;
    }
}