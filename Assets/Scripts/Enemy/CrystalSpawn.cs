using System;
using UnityEngine;
using System.Collections.Generic;

public class CrystalSpawn : MonoBehaviour
{
    [SerializeField] private Transform _crystalSpawn;
    [SerializeField] private GameObject _crystalPrefab;
    [SerializeField] private Transform _ground;
    [SerializeField] private ParticleSystem _Score;

    private IDying _enemy;

    private void Awake()
    {
        _enemy = GetComponent<IDying>();
    }

    private void OnEnable()
    {
        _enemy.Die += OnEnemyDiy;
    }

    private void OnDisable()
    {
        _enemy.Die -= OnEnemyDiy;
    }

    private void OnEnemyDiy()
    {
        _Score.Play();
        Instantiate(_crystalPrefab, _crystalSpawn.position, Quaternion.identity, _ground);
    }
}