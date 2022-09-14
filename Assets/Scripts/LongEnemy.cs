using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class LongEnemy : Enemy
{
    [SerializeField] private Material _gap;
    [SerializeField] private MeshRenderer _boxRenderer;

    protected override void TakeDamage()
    {
        if (Heath <= 3)
        {
            _boxRenderer.material = _gap;
        }
        base.TakeDamage();
    }
}
