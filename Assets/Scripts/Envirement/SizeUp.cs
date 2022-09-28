using System;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    public event Action SizeUped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            SizeUped?.Invoke();
            Destroy(gameObject);
        }
    }
}