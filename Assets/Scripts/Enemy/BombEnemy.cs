using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour, IDying
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Material _material;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private Transform _plane;

    private Animator _animator;
    private BoxCollider _boxCollider;

    private List<LongEnemy> _longEnemys = new List<LongEnemy>();
    private List<ShortEnemy> _shortEnemys = new List<ShortEnemy>();

    public event Action Die;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out LongEnemy longEnemy))
            _longEnemys.Add(longEnemy);

        if (collider.TryGetComponent(out ShortEnemy shortEnemy))
        {
            _shortEnemys.Add(shortEnemy);
            shortEnemy.Dead += RemoveEnemy;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out LongEnemy longEnemy))
            _longEnemys.Remove(collider.GetComponent<LongEnemy>());

        if (collider.TryGetComponent(out ShortEnemy shortEnemy))
            _shortEnemys.Remove(collider.GetComponent<ShortEnemy>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            for (int i = 0; i < _longEnemys.Count; i++)
            {
                if(_longEnemys[i] != null)
                    _longEnemys[i].TakeDamage();
            }   
            for (int i = _shortEnemys.Count - 1; i >= 0; i--)
            {
                if(_shortEnemys[i] != null)
                { 
                    _shortEnemys[i].Dead -= RemoveEnemy;
                    _shortEnemys[i].TakeDamage();
                }
            }

            Destroy(_bomb.gameObject);
            transform.SetParent(_plane);
            _boxCollider.enabled = false;
            _renderer.material = _material;
            _animator.enabled = false;
            Die.Invoke();
        }
    }

    private void RemoveEnemy(ShortEnemy shortEnemy)
    {
        _shortEnemys.Remove(shortEnemy);
        shortEnemy.Dead -= RemoveEnemy;
    }
}
