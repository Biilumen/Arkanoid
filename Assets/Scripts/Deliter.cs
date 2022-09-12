using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
