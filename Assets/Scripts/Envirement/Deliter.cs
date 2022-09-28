using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            Destroy(ball.gameObject);
        }
    }
}
