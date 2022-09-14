using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatredBlosk : MonoBehaviour
{
    private MeshCollider _meshCollider;

    private void Awake()
    {
        _meshCollider = GetComponent<MeshCollider>();
        _meshCollider.isTrigger = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Playne playne))
        {
            _meshCollider.isTrigger = false;
        }
    }
}