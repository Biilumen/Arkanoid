using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private int _enemyCount;
  
    private List<IDying> _enemys = new List<IDying>();

    public event Action Empty;

    private void OnEnable()
    {
        foreach (IDying enemy in _enemys) 
        {
            enemy.Die += OnEnemyDie;
        }
    }

    private void OnDisable()
    {
        foreach (IDying enemy in _enemys)
        {
            enemy.Die -= OnEnemyDie;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            _enemys.Add(GetComponentInChildren<IDying>());
        }
    }

    private void OnEnemyDie()
    {
        _enemyCount--;

        if(_enemyCount == 0)
        {
            Empty?.Invoke();
        }
    }
}