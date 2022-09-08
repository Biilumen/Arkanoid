using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
        
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.back * 500f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        _rigidbody.AddForce(Vector3.back * 500f);
    }
}
