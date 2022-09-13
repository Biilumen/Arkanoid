using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _heath;
    [SerializeField] private RayfireBomb _rayfire;
    [SerializeField] private Transform _plane;
    [SerializeField] private List<Transform> _blocks;

    private BoxCollider _boxCollider;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _heath--;
        if(_heath <= 0)
        {
            _rayfire.Explode(0f);
            _animator.enabled = false;
            _boxCollider.enabled = false;
            transform.SetParent(_plane);
        }
    }
}
