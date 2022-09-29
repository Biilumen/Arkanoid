using System;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] private float _scale;
    
    private float _startFixedDeltaTime;
    private float _startScale; 

    private void OnEnable()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
        _startScale = _scale;
    }

    private void Update()
    {
        Time.timeScale = _scale;
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDisable()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime; 
        Time.timeScale = 1f;
    }
}
