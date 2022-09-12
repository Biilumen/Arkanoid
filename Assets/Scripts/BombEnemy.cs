using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    private List<Enemy> _enemys = new List<Enemy>();

    private void OnTriggerEnter(Collider collider)
    {
        _enemys.Add(collider.GetComponent<Enemy>());
    }

    private void OnTriggerExit(Collider collider)
    {
        _enemys.Remove(collider.GetComponent<Enemy>());
    }
}
