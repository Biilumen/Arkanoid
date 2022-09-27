using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine.Serialization;

public class Waves : MonoBehaviour
{
    [FormerlySerializedAs("waves")] [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _duration;
    [SerializeField] private float _distance;
    [SerializeField] private TMP_Text _text;

    private int _index;

    private int _wavesCount;

    public event Action FinalWave;

    private void OnEnable()
    {
        _wavesCount = _waves.Count;
        _text.text = ($"{_index}/ {_waves.Count}");

        foreach (Wave wave in _waves)
        {
            wave.Empty += OnWaveEmty;
        }
    }

    private void OnDisable()
    {
        foreach (Wave wave in _waves)
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

        if (_index != _wavesCount)
        {
            _index++;
            _text.text = ($"{_index}/ {_waves.Count}");
        }
    }
}