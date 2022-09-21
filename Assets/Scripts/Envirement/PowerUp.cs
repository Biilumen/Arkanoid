using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public event Action PowerUped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player)) 
        { 
            PowerUped?.Invoke();
            Destroy(gameObject);
        }
    }
}