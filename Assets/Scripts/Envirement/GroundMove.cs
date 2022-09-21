using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<GameObject> _planeList;
    [SerializeField] private Animator _planeAanimator;

    public int PlaneListCount => _planeList.Count;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * _speed);
    }
    
    public void Stop()
    {
        _speed = 0;
        _planeAanimator.enabled = false;
    }
}
