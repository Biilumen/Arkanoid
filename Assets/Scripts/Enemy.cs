using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _heath;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            TakeDamage();    
        }
    }

    private void TakeDamage()
    {
        _heath--;
        if(_heath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
