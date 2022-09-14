using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class LongEnemy : Enemy
{
    [SerializeField] private Material _gap;
    [SerializeField] private GameObject _cube;
    [SerializeField] private MeshRenderer _boxRenderer;

    protected override void TakeDamage()
    {
        if (Health >= 1)
        {
            _boxRenderer.material = _gap;
                print("sads");
        }
        base.TakeDamage();
    }
}
