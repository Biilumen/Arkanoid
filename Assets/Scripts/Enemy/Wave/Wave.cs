using System;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemys;

    private int _enemyCount;
    private List<IDying> _Dyings = new List<IDying>();

    public event Action Empty;

    private void OnEnable()
    {
        foreach (GameObject enemy in _enemys) 
        {
            _Dyings.Add(enemy.GetComponent<IDying>());
        }

        foreach(IDying dying in _Dyings)
        {
            dying.Die += OnEnemyDie;
        }
        _enemyCount = _Dyings.Count;
    }

    private void OnDisable()
    {
        foreach (IDying dying in _Dyings)
        {
            dying.Die += OnEnemyDie;
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