using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliter : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        collision.transform.SetParent(transform);
        Destroy(collision.gameObject);
    }
}
