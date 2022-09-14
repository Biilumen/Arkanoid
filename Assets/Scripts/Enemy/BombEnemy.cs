using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    private List<LongEnemy> _enemys = new List<LongEnemy>();

    private void OnTriggerEnter(Collider collider)
    {
        _enemys.Add(collider.GetComponent<LongEnemy>());
    }

    private void OnTriggerExit(Collider collider)
    {
        _enemys.Remove(collider.GetComponent<LongEnemy>());
    }
}
