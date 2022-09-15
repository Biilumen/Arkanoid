using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Material _material;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private Transform _transform;

    private Animator _animator;
    private BoxCollider _boxCollider;

    private List<LongEnemy> _longEnemys = new List<LongEnemy>();
    private List<ShortEnemy> _shortEnemys = new List<ShortEnemy>();

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        _longEnemys.Add(collider.GetComponent<LongEnemy>());
        _shortEnemys.Add(collider.GetComponent<ShortEnemy>());
    }

    private void OnTriggerExit(Collider collider)
    {
        _longEnemys.Remove(collider.GetComponent<LongEnemy>());
        _shortEnemys.Remove(collider.GetComponent<ShortEnemy>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            
            foreach(LongEnemy longEnemy in _longEnemys)
            {
                if(longEnemy != null)
                    longEnemy.TakeDamage();
            }

            foreach (ShortEnemy shortEnemy in _shortEnemys)
            {
                if(shortEnemy != null)
                    shortEnemy.TakeDamage();
            }

        Destroy(_bomb.gameObject);
        _boxCollider.enabled = false;
        _renderer.material = _material;
        _animator.enabled = false;
        }
    }
}
