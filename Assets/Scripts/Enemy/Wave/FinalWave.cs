using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWave : MonoBehaviour
{
    [SerializeField] private Transform _ballposition;
    [SerializeField] private List<Rigidbody> _balls;
    [SerializeField] private Waves _waves;

    private void OnEnable()
    {
        _waves.FinalWave += OnFinalWave;
    }

    private void OnDisable()
    {
        _waves.FinalWave -= OnFinalWave;
    }

    private void OnFinalWave()
    {
        for (int i = 1; i < _balls.Count; i++)
        {
            _balls[i].gameObject.SetActive(false);
        }
        _balls[0].velocity = Vector3.zero;
        _balls[0].transform.position = _ballposition.position;
        _balls[0].AddForce(Vector3.back * 2);
    }
}
