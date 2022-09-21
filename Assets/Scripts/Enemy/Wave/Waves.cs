using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Waves : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;
    [SerializeField] private float _duration;
    [SerializeField] private float _distance;

    private int _wavesCount;

    public event Action FinalWave;

    private void OnEnable()
    {
        _wavesCount = waves.Count;
        foreach (Wave wave in waves)
        {
            wave.Empty += OnWaveEmty;
        }
    }

    private void OnDisable()
    {
        foreach (Wave wave in waves)
        {
            wave.Empty += OnWaveEmty;
        }
    }

    private void OnWaveEmty()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z - _distance), _duration);
        _wavesCount--;

        if(_wavesCount == 0)
        {
            FinalWave?.Invoke();
        }
    }
}